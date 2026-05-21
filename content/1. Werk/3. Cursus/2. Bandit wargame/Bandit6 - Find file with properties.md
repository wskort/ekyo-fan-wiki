---
tags: Techniek
---
# Bandit Level 6
The password for the next level is stored in a file somewhere under the **inhere** directory and has all of the following properties:

-   human-readable
-   1033 bytes in size
-   not executable

## Setup from [[Bandit5 - Read human-readable file]]
```bash
ssh bandit5@bandit.labs.overthewire.org -p 2220
``` 

Password: `koReBOKuIDDepwhWk7jZC0RTdopnAYKh`

## Method
```bash
$ cd inhere
$ ls
# Yikes, lots of folders. Time for some logic filtering! 

# find 					find
	# -readable			human-readable
	# -size 1033c		1033 bytes in size
	# ! -executable		NOT executable
$ find -readable -size 1033c ! -executable
./maybehere07/.file2

$ cat ./maybehere07/.file2
DXjZPULLxYr17uwoI01bNLQbtFemEgo7
```

Password: `DXjZPULLxYr17uwoI01bNLQbtFemEgo7`

### Commands
* `ssh` secure shell to another computer
	* `[user]@[host]` connect to `[host]` as username `[user]`
	* `-p [port]` use this port instead of the default.
* `ls` list directory contents
	* `-a` including hidden files
	* `-l` list on separate lines
	* `-R` recursive (including inside directories)
* `cd [directory]` change (to) directory
	* `.` move up a node
	* `..` move to top directory
	* `~/` go to user's home directory
* `cat` (short for concatenate, aka print as string)
* `file` determine filetype
* `du` estimate fule space usage
* `find` search for file in directory hierarchy
	* `-readable` find a human-readable file.
	* `-executable` find executable file
	* `! [expr]` true if `[expr]` is false
	* `-size [n]`
		* `[n]c` amount in bytes

### See further
[[Bash]]