---
tags: Techniek
---
# Bandit Level 5
The password for the next level is stored in the only human-readable file in the **inhere** directory. Tip: if your terminal is messed up, try the “reset” command.

## Setup from [[Bandit4 - Read hidden file]]
```bash
ssh bandit4@bandit.labs.overthewire.org -p 2220
``` 

Password: `pIwrPrtPN36QITSp3EQaw936yaFoFgAB`

## Method
```bash
$ ls
inhere

$ cd inhere
$ ls
-file00  
-file01  
-file02  
-file03  
-file04  
-file05  
-file06  
-file07  
-file08  
-file09

# Repeat the following for each filename
$ file ./-file01

# The only ASCII file is -file07; the rest is binary data.
$ cat ./-file07
koReBOKuIDDepwhWk7jZC0RTdopnAYKh
```
Password: `koReBOKuIDDepwhWk7jZC0RTdopnAYKh`

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