---
tags: Techniek
---
# Bandit Level 23
A program is running automatically at regular intervals from **cron**, the time-based job scheduler. Look in **/etc/cron.d/** for the configuration and see what command is being executed.

**NOTE:** Looking at shell scripts written by other people is a very useful skill. The script for this level is intentionally made easy to read. If you are having problems understanding what it does, try executing it to see the debug information it prints.

## Setup from [[Bandit22 - Cron jobs]]
```bash
ssh bandit22@bandit.labs.overthewire.org -p 2220
``` 

Password:
```
Yk7owGAcWjwMVRwrTesJEwB7WVOiILLI
```

## Method
```bash
# Okay, so what's in /etc/cron.d?
$ ls /etc/cron.d
cronjob_bandit15_root  cronjob_bandit22  cronjob_bandit24
cronjob_bandit17_root  cronjob_bandit23  cronjob_bandit25_root

# Cool, let's check out the one for this level. 
$ cat /etc/cron.d/cronjob_bandit23
@reboot bandit23 /usr/bin/cronjob_bandit23.sh  &> /dev/null
* * * * * bandit23 /usr/bin/cronjob_bandit23.sh  &> /dev/null
# On reboot, and every minute:
# as user bandit23
# execute /usr/bin/cronjob_bandit23.sh
# and toss log into void

# So what does that file do?
$ cat /usr/bin/cronjob_bandit23.sh
```

The file:
```bash
#!/bin/bash

myname=$(whoami)
mytarget=$(echo I am user $myname | md5sum | cut -d ' ' -f 1)

echo "Copying passwordfile /etc/bandit_pass/$myname to /tmp/$mytarget"

cat /etc/bandit_pass/$myname > /tmp/$mytarget
```

Executing this step by step straight into the command line, so I see the actual output:
```bash
$ myname=$(whoami)
$ mytarget=$(echo I am user $myname | md5sum | cut -d ' ' -f 1)
# Take a string containing my username, hash it with MD5, and do some final text manipulation.

$ echo "Copying passwordfile /etc/bandit_pass/$myname to /tmp/$mytarget"
Copying passwordfile /etc/bandit_pass/bandit22 to /tmp/8169b67bd894ddbb4412f91573b38db3
# As we can see above, a unique (but static) file location has been generated

$ cat /etc/bandit_pass/$myname > /tmp/$mytarget
# Now we put the password in this secret location. 

# Okay, so what did you just write there?
$ cat /tmp/$mytarget
Yk7owGAcWjwMVRwrTesJEwB7WVOiILLI

# That's the *previous* password, because I did this as bandit22.
# But the cronjob does it as bandit23! So let's try that.

$ newtarget=$(echo I am user bandit23 | md5sum | cut -d ' ' -f 1)
$ echo "Copying passwordfile /etc/bandit_pass/bandit23 to /tmp/$newtarget"
Copying passwordfile /etc/bandit_pass/bandit23 to /tmp/8ca319486bfbbc3663ea0fbe81326349

# So this is where the cron-job is writing the password!

$ cat /tmp/$newtarget
jc1udXuA1tiHqjIsL8yaapX5XIAI6i0n
```

Password: 
```
jc1udXuA1tiHqjIsL8yaapX5XIAI6i0n
```

### See further
[[Bash]]