---
tags: Techniek
---
# Bandit Level 32
There is a git repository at `ssh://bandit31-git@localhost/home/bandit31-git/repo`. The password for the user `bandit31-git` is the same as for the user `bandit31`.

Clone the repository and find the password for the next level.

Commands you may need to solve this level:
git

## Setup from [[Bandit31 - Git tags]]
```bash
ssh bandit31@bandit.labs.overthewire.org -p 2220
``` 

Password:
```
47e603bb428404d265f59c42920d81e5
```

## Method
The password for the git repository is the same as for entering this level. 

```bash
$ git clone ssh://bandit31-git@localhost/home/bandit31-git/repo /tmp/gitteke32

$ cd /tmp/gitteke32
$ ls
README.md
$ cat README.md
This time your task is to push a file to the remote repository.

Details:
    File name: key.txt
    Content: 'May I come in?'
    Branch: master
# Oh, fun!

$ echo "May I come in?" > key.txt
$ git add key.txt
The following paths are ignored by one of your .gitignore files:
key.txt
Use -f if you really want to add them.
# sudo get me a sandwhich!
$ git add key.txt -f

# Staging our change...
$ git commit -m "Adding a key!"
[master 1ac774b] Adding a key!
 1 file changed, 1 insertion(+)
 create mode 100644 key.txt

# Look, there it is!
$ git status
On branch master
Your branch is ahead of 'origin/master' by 1 commit.
  (use "git push" to publish your local commits)
nothing to commit, working tree clean

$ git push
Could not create directory '/home/bandit31/.ssh'.
The authenticity of host 'localhost (127.0.0.1)' can't be established.
ECDSA key fingerprint is SHA256:98UL0ZWr85496EtCRkKlo20X3OPnyPSB5tB5RPbhczc.
Are you sure you want to continue connecting (yes/no)? yes
Failed to add the host to the list of known hosts (/home/bandit31/.ssh/known_hosts).
This is a OverTheWire game server. More information on http://www.overthewire.org/wargames

bandit31-git@localhost's password:
Counting objects: 3, done.
Delta compression using up to 2 threads.
Compressing objects: 100% (2/2), done.
Writing objects: 100% (3/3), 323 bytes | 0 bytes/s, done.
Total 3 (delta 0), reused 0 (delta 0)
remote: ### Attempting to validate files... ####
remote:
remote: .oOo.oOo.oOo.oOo.oOo.oOo.oOo.oOo.oOo.oOo.
remote:
remote: Well done! Here is the password for the next level:
remote: 56a9bf19c63d650ce78e6ec0354ee45e
remote:
remote: .oOo.oOo.oOo.oOo.oOo.oOo.oOo.oOo.oOo.oOo.
remote:
To ssh://localhost/home/bandit31-git/repo
 ! [remote rejected] master -> master (pre-receive hook declined)
error: failed to push some refs to 'ssh://bandit31-git@localhost/home/bandit31-git/repo'

```

Password: 
```
56a9bf19c63d650ce78e6ec0354ee45e
```

### See further
[[Bash]]
[[GIT]]