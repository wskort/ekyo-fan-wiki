---
tags: Techniek
---
# Bandit Level 21
There is a setuid binary in the homedirectory that does the following: it makes a connection to localhost on the port you specify as a commandline argument. It then reads a line of text from the connection and compares it to the password in the previous level (bandit20). If the password is correct, it will transmit the password for the next level (bandit21).

**NOTE:** Try connecting to your own network daemon to see if it works as you think

## Setup from [[Bandit20 - Setuid binary file]]
```bash
ssh bandit20@bandit.labs.overthewire.org -p 2220
``` 

Password:
```
GbKksEFF4yrVs6il55v6gwY5aVje5f0j
```

## Method
```bash
$ ls
suconnect

# Hoe werkt dit eigenlijk?
$ ./suconnect
Usage: ./suconnect <portnumber>
This program will connect to the given port on localhost using TCP. If it receives the correct password from the other side, the next password is transmitted back.

# Oke, dus nu heb ik twee schermen tegelijk nodig
# en een bestand met het wachtwoord

# Het wachtwoord staat hier (alleen leesbaar als bandit20)
$ cat /etc/bandit_pass/bandit20
GbKksEFF4yrVs6il55v6gwY5aVje5f0j

# In dit scherm zetten we de connectie klaar
$ nc -l -p 31337 < /etc/bandit_pass/bandit20
# netcat
# 	 -listen mode
#       -port 31337
#                < redirect to file
```

```bash
# Login met tweede shell
$ ./suconnect 31337
Read: GbKksEFF4yrVs6il55v6gwY5aVje5f0j
Password matches, sending next password
```

```bash
# Terug op eerste shell
$ nc -l -p 31337 < /etc/bandit_pass/bandit20
# After connection has ended:
gE269g2h3mw3pwgrj0Ha9Uoqen1c9DGr
```

Password: 
```
gE269g2h3mw3pwgrj0Ha9Uoqen1c9DGr
```


### See further
[[Bash]]