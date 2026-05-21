---
tags: Techniek
---
# Bandit Level 2
The password for the next level is stored in a file called **\-** located in the home directory.

## Setup from [[Bandit1 - Read file]]
```bash
ssh bandit1@bandit.labs.overthewire.org -p 2220
``` 

Password: `boJ9jbbUNNfktd78OOpsqOltutMc3MY1`

## Method
```bash
$ ls
- 

# The character - starts an option. 
# Avoid this by using the full pathname.
$ cat ./-
CV1DtqXWVFXTvM2F0k09SHz0YwRINYA9
```

Password: `CV1DtqXWVFXTvM2F0k09SHz0YwRINYA9`

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

https://unix.stackexchange.com/questions/347332/what-characters-need-to-be-escaped-in-files-without-quotes