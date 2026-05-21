---
tags: Techniek
---
# Bandit Level 11
The password for the next level is stored in the file **data.txt**, which contains base64 encoded data.

## Setup from [[Bandit10 - Find readable string with word]]
```bash
ssh bandit10@bandit.labs.overthewire.org -p 2220
``` 

Password: `truKLdjsbJ5g7yyJ2X2R0o3a5HQJFuLk`

## Method
```bash
$ cat data.txt
VGhlIHBhc3N3b3JkIGlzIElGdWt3S0dzRlc4TU9xM0lSRnFyeEUxaHhUTkViVVBSCg==
# This is the base64 encoded text. 
# The == at the end is a common feature of base64 encoding.

# Now decode with base64 -d (=decode).
$ base64 -d data.txt
The password is IFukwKGsFW8MOq3IRFqrxE1hxTNEbUPR
```

Password: `IFukwKGsFW8MOq3IRFqrxE1hxTNEbUPR`

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
* `strings` return only lines that are strings
* `base64 [option] [file]` encode or decode file or text.
	* `-d` decode data
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
[[Encoding&decoding]]