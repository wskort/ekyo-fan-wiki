---
tags: Techniek
---
# Bandit Level 26
Logging in to bandit26 from bandit25 should be fairly easy… The shell for user bandit26 is not **/bin/bash**, but something else. Find out what it is, how it works and how to break out of it.

Commands you may need to solve this level:
ssh, cat, more, vi, ls, id, pwd

## Setup from [[Bandit25 - Brute-forcing]]
```bash
ssh bandit25@bandit.labs.overthewire.org -p 2220
``` 

Password:
```
uNG9O58gUE7snukf3bvZ0rxhtnjzSGzG
```

## Method
```bash
# Let's look around...
$ ls
bandit26.sshkey
# Oh! Well then!
$ ssh bandit26@localhost -i bandit26.sshkey
# Login is successful, but then connection is closed immediately. Hm.

$ echo "hello world" | ssh bandit26@localhost -i bandit26.sshkey
# Now *just* before closing the connection, my text is printed and it responds... kind of?

  Enjoy your stay!

hello world
::::::::::::::
/home/bandit26/text.txt
::::::::::::::
  _                     _ _ _   ___   __
 | |                   | (_) | |__ \ / /
 | |__   __ _ _ __   __| |_| |_   ) / /_
 | '_ \ / _` | '_ \ / _` | | __| / / '_ \
 | |_) | (_| | | | | (_| | | |_ / /| (_) |
 |_.__/ \__,_|_| |_|\__,_|_|\__|____\___/

# oookay, so it seems like it is printing the text.txt file
# and that file is the ascii art of the level. 

# let's see which shell is run in the first place...
$ more /etc/passwd
(...)
bandit25:x:11025:11025:bandit level 25:/home/bandit25:/bin/bash
bandit26:x:11026:11026:bandit level 26:/home/bandit26:/usr/bin/showtext

# Showtext? What is that?
$ cat /usr/bin/showtext
#!/bin/sh

export TERM=linux

more ~/text.txt
exit 0

# So what it does is: display the text in text.txt (that ascii art of the level name), using the more command. 

# Now we force that pagination to stay in there for a while longer:
# Adjust your terminal window size to fewer than 6 lines
$ ssh bandit26@localhost -i bandit26.sshkey
```

![[Bandit26.png]]

Now type `v` to enter the vim editor, and switch files by typing `:e /etc/bandit_pass/bandit26`

![[Bandit26 1.png]]

Password: 
```
5czgV9L3Xx8JPOyRbXh6lQbmIOWvPT6Z
```

### See further
[[Bash]]