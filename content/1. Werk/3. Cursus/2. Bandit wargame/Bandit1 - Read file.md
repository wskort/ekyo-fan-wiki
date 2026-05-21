---
tags: Techniek
---
# Bandit Level 1
The password for the next level is stored in a file called **readme** located in the home directory. Use this password to log into bandit1 using SSH. Whenever you find a password for a level, use SSH (on port 2220) to log into that level and continue the game.

## Setup from [[Bandit0 - Login]]
```bash
ssh bandit0@bandit.labs.overthewire.org -p 2220
``` 

Password: `bandit0`

## Method
```bash
$ ls 
readme

$ cat readme
boJ9jbbUNNfktd78OOpsqOltutMc3MY1
```

Password: `boJ9jbbUNNfktd78OOpsqOltutMc3MY1`

### Commands
* `ssh` secure shell to another computer
	* `[user]@[host]` connect to `[host]` as username `[user]`
	* `-p [port]` use this port instead of the default.
* `ls` list directory contents
	* `-a` including hidden files
	* `-l` list on separate lines
* `cd` change directory
* `cat` (short for concatenate, aka print as string)
* `file` determine filetype
* `du` estimate fule space usage
* `find` search for file in directory hierarchy

### See further
[[Bash]]