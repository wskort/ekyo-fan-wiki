---
tags: Techniek
---
# Bandit Level 7
The password for the next level is stored **somewhere on the server** and has all of the following properties:

-   owned by user bandit7
-   owned by group bandit6
-   33 bytes in size

## Setup from [[Bandit6 - Find file with properties]]
```bash
ssh bandit6@bandit.labs.overthewire.org -p 2220
``` 

Password: `DXjZPULLxYr17uwoI01bNLQbtFemEgo7`

## Method
```bash
# find 					find
	# /					anywhere on the system
	# -user bandit7		owned by user bandit7
	# -group bandit6	owned by group bandit6
	# -size 33c			33 bytes in size
	# 2>/dev/null		discard error results
$ find / -user bandit7 -group bandit6 -size 33c 2>/dev/null
/var/lib/dpkg/info/bandit7.password

$ cat /var/lib/dpkg/info/bandit7.password
HKBPTKQnIay4Fw76bEy8PVxKEDQRKTzs
```

Password: `HKBPTKQnIay4Fw76bEy8PVxKEDQRKTzs`

### Commands
* `ssh` secure shell to another computer
	* `[user]@[host]` connect to `[host]` as username `[user]`
	* `-p [port]` use this port instead of the default.
* `ls` list directory contents
	* `-a` including hidden files
	* `-l` list on separate lines
	* `-R` recursive (including inside directories)
* `cd [directory]` change (to) directory
	* `.` current directory
	* `..` move up a directory
	* `/` root directory
	* `~/` go to user's home directory
* `cat` (short for concatenate, aka print as string)
* `file` determine filetype
* `du` estimate file space usage
* `find` search for file in directory hierarchy
	* `-readable` find a human-readable file.
	* `-executable` find executable file
	* `! [expr]` true if `[expr]` is false
	* `-size [n]`
		* `[n]c` amount in bytes
	* `-group [gname]` file belongs to group `[gname]`
	* `-user [uname]` file belongs to `[uname]` 
	* `2>/dev/null` For result type 2(=error), send to THE VOID
* `grep` print lines matching a pattern (regex?)

* Result type
	* `0` = standard input (stdin)
	* `1` = standard output (stout)
	* `2` = standard error (sterr)

### See further
[[Bash]]