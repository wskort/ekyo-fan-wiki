---
tags: Techniek
---
# Bandit Level 31
There is a git repository at `ssh://bandit30-git@localhost/home/bandit30-git/repo`. The password for the user `bandit30-git` is the same as for the user `bandit30`.

Clone the repository and find the password for the next level.

Commands you may need to solve this level:
git

## Setup from [[Bandit30 - Git branches]]
```bash
ssh bandit30@bandit.labs.overthewire.org -p 2220
``` 

Password:
```
5b90576bedb2cc04c86a9e924ce42faf
```

## Method
The password for the git repository is the same as for entering this level. 

```bash
$ git clone ssh://bandit30-git@localhost/home/bandit30-git/repo /tmp/willeke31

$ cd /tmp/willeke31
$ ls
README.md
$ cat README.md
just an epmty file... muahaha
# ... troll. 

$ git tag
secret
# What is the message attached to this tag?
$ git show secret
47e603bb428404d265f59c42920d81e5
```

Password: 
```
47e603bb428404d265f59c42920d81e5
```

### See further
[[Bash]]
[[GIT]]