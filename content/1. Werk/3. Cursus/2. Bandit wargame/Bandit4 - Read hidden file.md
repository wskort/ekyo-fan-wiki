---
tags: Techniek
---
# Bandit Level 4
The password for the next level is stored in a hidden file in the **inhere** directory.

## Setup from [[Bandit3 - Read spaced filename]]
```bash
ssh bandit3@bandit.labs.overthewire.org -p 2220
``` 

Password: `UmHadQclWmgdLOKQ3YNgjWxGoRMb5luK`

## Method
```bash
$ ls
inhere

$ cd inhere
$ ls -a
.  ..  .hidden

$ cat .hidden
pIwrPrtPN36QITSp3EQaw936yaFoFgAB
```
Password: `pIwrPrtPN36QITSp3EQaw936yaFoFgAB`

### Commands
* `ssh` secure shell to another computer
	* `[user]@[host]` connect to `[host]` as username `[user]`
	* `-p [port]` use this port instead of the default.
* `ls` list directory contents
	* `-a` including hidden files
	* `-l` list on separate lines
* `cd [directory]` change (to) directory
	* `.` move up a node
	* `..` move to top directory
	* `~/` go to user's home directory
* `cat` (short for concatenate, aka print as string)
* `file` determine filetype
* `du` estimate fule space usage
* `find` search for file in directory hierarchy

### See further
[[Bash]]