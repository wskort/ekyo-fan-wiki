---
tags: Techniek
---
# Bandit Level 29
There is a git repository at `ssh://bandit28-git@localhost/home/bandit28-git/repo`. The password for the user `bandit28-git` is the same as for the user `bandit28`.

Clone the repository and find the password for the next level.

Commands you may need to solve this level:
git

## Setup from [[Bandit28 - Git setup]]
```bash
ssh bandit28@bandit.labs.overthewire.org -p 2220
``` 

Password:
```
0ef186ac70e04ea33b4c1853d2526fa2
```

## Method
The password for the git repository is the same as for entering this level. 

```bash
# First, let's fetch the repo. 
$ git clone ssh://bandit28-git@localhost/home/bandit28-git/repo /tmp/willeke29
Cloning into '/tmp/willeke29'...
Could not create directory '/home/bandit28/.ssh'.
The authenticity of host 'localhost (127.0.0.1)' can't be established.
ECDSA key fingerprint is SHA256:98UL0ZWr85496EtCRkKlo20X3OPnyPSB5tB5RPbhczc.
Are you sure you want to continue connecting (yes/no)? yes
Failed to add the host to the list of known hosts (/home/bandit28/.ssh/known_hosts).
This is a OverTheWire game server. More information on http://www.overthewire.org/wargames

bandit28-git@localhost's password:
remote: Counting objects: 9, done.
remote: Compressing objects: 100% (6/6), done.
remote: Total 9 (delta 2), reused 0 (delta 0)
Receiving objects: 100% (9/9), done.
Resolving deltas: 100% (2/2), done.

# What have we got here?
$ cd /tmp/willeke29
$ ls
README.md
$ cat README.md
# Bandit Notes
Some notes for level29 of bandit.

## credentials

- username: bandit29
- password: xxxxxxxxxx


# Someone has masked the password, but maybe an earlier version did have the full thing?
$ git log
commit edd935d60906b33f0619605abd1689808ccdd5ee
Author: Morla Porla <morla@overthewire.org>
Date:   Thu May 7 20:14:49 2020 +0200

    fix info leak

commit c086d11a00c0648d095d04c089786efef5e01264
Author: Morla Porla <morla@overthewire.org>
Date:   Thu May 7 20:14:49 2020 +0200

    add missing data

commit de2ebe2d5fd1598cd547f4d56247e053be3fdc38
Author: Ben Dover <noone@overthewire.org>
Date:   Thu May 7 20:14:49 2020 +0200

    initial commit of README.md
	
# Cool... show me the the one before 'fix info leak', please!
$ diff c086d11a00c0648d095d04c089786efef5e01264
diff --git a/README.md b/README.md
index 3f7cee8..5c6457b 100644
--- a/README.md
+++ b/README.md
@@ -4,5 +4,5 @@ Some notes for level29 of bandit.
 ## credentials

 - username: bandit29
-- password: bbc96594b4e001778eee9975372716b2
+- password: xxxxxxxxxx

```

Password: 
```
bbc96594b4e001778eee9975372716b2
```

### See further
[[Bash]]
[[GIT]]