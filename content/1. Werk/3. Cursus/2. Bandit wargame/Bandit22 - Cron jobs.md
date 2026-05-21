---
tags: Techniek
---
# Bandit Level 22
A program is running automatically at regular intervals from **cron**, the time-based job scheduler. Look in **/etc/cron.d/** for the configuration and see what command is being executed.

## Setup from [[Bandit21 - TCP connection]]
```bash
ssh bandit21@bandit.labs.overthewire.org -p 2220
``` 

Password:
```
gE269g2h3mw3pwgrj0Ha9Uoqen1c9DGr
```

## Method
```bash
# Okay, so what's in /etc/cron.d?
$ ls /etc/cron.d
cronjob_bandit15_root  cronjob_bandit22  cronjob_bandit24
cronjob_bandit17_root  cronjob_bandit23  cronjob_bandit25_root

# Cool, let's check out the one for this level. 
$ cat /etc/cron.d/cronjob_bandit22
@reboot bandit22 /usr/bin/cronjob_bandit22.sh &> /dev/null
* * * * * bandit22 /usr/bin/cronjob_bandit22.sh &> /dev/null
# On reboot, and every minute:
# as user bandit22
# execute /usr/bin/cronjob_bandit22.sh
# and toss log into void

# So what does that file do?
$ cat /usr/bin/cronjob_bandit22.sh
#!/bin/bash
chmod 644 /tmp/t7O6lds9S0RqQh9aMcz6ShpAoZKF7fgv
cat /etc/bandit_pass/bandit22 > /tmp/t7O6lds9S0RqQh9aMcz6ShpAoZKF7fgv
# It looks like it presets a temp file, and then stores the current password there. 

# Let's see!
$ cat /etc/bandit_pass/bandit22
cat: /etc/bandit_pass/bandit22: Permission denied
# And yet...
$ cat /tmp/t7O6lds9S0RqQh9aMcz6ShpAoZKF7fgv
Yk7owGAcWjwMVRwrTesJEwB7WVOiILLI
```

Password: 
```
Yk7owGAcWjwMVRwrTesJEwB7WVOiILLI
```


### See further
[[Bash]]