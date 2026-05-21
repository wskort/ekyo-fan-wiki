---
tags: Techniek
---
# Bandit Level 30
There is a git repository at `ssh://bandit29-git@localhost/home/bandit29-git/repo`. The password for the user `bandit29-git` is the same as for the user `bandit29`.

Clone the repository and find the password for the next level.

Commands you may need to solve this level:
git

## Setup from [[Bandit29 - Git version history]]
```bash
ssh bandit29@bandit.labs.overthewire.org -p 2220
``` 

Password:
```
bbc96594b4e001778eee9975372716b2
```

## Method
The password for the git repository is the same as for entering this level. 

```bash
$ git clone ssh://bandit29-git@localhost/home/bandit29-git/repo /tmp/willeke30

$ cd /tmp/willeke30
$ ls
README.md
$ cat README.md
# Bandit Notes
Some notes for bandit30 of bandit.

## credentials

- username: bandit30
- password: <no passwords in production!>

# Is there a different branch?
$ git branch -a
* master
  remotes/origin/HEAD -> origin/master
  remotes/origin/dev
  remotes/origin/master
  remotes/origin/sploits-dev
  
  # I'll take a development branch, plx!
  $ git checkout dev
Branch dev set up to track remote branch dev from origin.
Switched to a new branch 'dev'
$ ls
code  README.md
$ cat README.md
# Bandit Notes
Some notes for bandit30 of bandit.

## credentials

- username: bandit30
- password: 5b90576bedb2cc04c86a9e924ce42faf
```

Password: 
```
5b90576bedb2cc04c86a9e924ce42faf
```

### See further
[[Bash]]
[[GIT]]