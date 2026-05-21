---
tags: Techniek
---
# Bandit Level 28
There is a git repository at `ssh://bandit27-git@localhost/home/bandit27-git/repo`. The password for the user `bandit27-git` is the same as for the user `bandit27`.

Clone the repository and find the password for the next level.

Commands you may need to solve this level:
git

## Setup from [[Bandit27 - Running commands from VIM]]
```bash
ssh bandit27@bandit.labs.overthewire.org -p 2220
``` 

Password:
```
3ba3118a22e93127a4ed485be72ef5ea
```

## Method
The password for the git repository is the same as for entering this level. 

```bash
# git clone 
# from ssh location
# to /tmp/willeke_git
$ git clone ssh://bandit27-git@localhost/home/bandit27-git/repo /tmp/willeke_git
Cloning into '/tmp/willeke_git'...
Could not create directory '/home/bandit27/.ssh'.
The authenticity of host 'localhost (127.0.0.1)' can't be established.
ECDSA key fingerprint is SHA256:98UL0ZWr85496EtCRkKlo20X3OPnyPSB5tB5RPbhczc.
Are you sure you want to continue connecting (yes/no)? yes
Failed to add the host to the list of known hosts (/home/bandit27/.ssh/known_hosts).
This is a OverTheWire game server. More information on http://www.overthewire.org/wargames

bandit27-git@localhost's password:
remote: Counting objects: 3, done.
remote: Compressing objects: 100% (2/2), done.
remote: Total 3 (delta 0), reused 0 (delta 0)
Receiving objects: 100% (3/3), 288 bytes | 0 bytes/s, done.

# Cool. What did we get?
$ ls -a /tmp/willeke_git/
.  ..  .git  README

# Let's begin with the README. 
$ cat /tmp/willeke_git/README
The password to the next level is: 0ef186ac70e04ea33b4c1853d2526fa2
```

Password: 
```
0ef186ac70e04ea33b4c1853d2526fa2
```

### See further
[[Bash]]
[[GIT]]