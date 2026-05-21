---
tags: Techniek
---
# Bandit Level 9
The password for the next level is stored in the file **data.txt** and is the only line of text that occurs only once.

## Setup from [[Bandit8 - Find word in file]]
```bash
ssh bandit8@bandit.labs.overthewire.org -p 2220
``` 

Password: `cvX2JJa4CFALtqS87jk27qwqGhBM9plV`

## Method
```bash
# The function 'uniq' needs sorted input. 
# You can use |pipes| to chain commands.

# sort data.txt		order the lines by alphabet
# |					use the result as input 
# uniq -u			output only unique lines
$ sort data.txt | uniq -u
UsvVyFSfZZWbi6wgC7dAFyFuR6jQQUhR
```

Password: `UsvVyFSfZZWbi6wgC7dAFyFuR6jQQUhR`

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
* `grep [OPTION] PATTERN [FILE]` search for PATTERN in each FILE or standard input, and return the entire line.
	* Standard PATTERN format is basic regular expression (BRE).
* `sort` sorts strings, default alphabetically
* `uniq` checks for unique lines
	* `-u` only print unique lines
* `strings` 
* `base64`
* `tr`
* `tar`
* `gzip`
* `bzip2`
* `xxd`

* Standard I/O types
	* `0` = standard input (stdin)
	* `1` = standard output (stdout)
	* `2` = standard error (stderr)

### See further
[[Bash]]
[[Command piping]]