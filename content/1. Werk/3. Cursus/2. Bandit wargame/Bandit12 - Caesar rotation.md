---
tags: Techniek
---
# Bandit Level 12
The password for the next level is stored in the file **data.txt**, where all lowercase (a-z) and uppercase (A-Z) letters have been rotated by 13 positions.

## Setup from [[Bandit11 - Decode base64]]
```bash
ssh bandit11@bandit.labs.overthewire.org -p 2220
``` 

Password: `IFukwKGsFW8MOq3IRFqrxE1hxTNEbUPR`

## Method
```bash
# cat				turn into string
# data.txt			the contents of this file
# |					and use it as input for:
# tr				translate characters
# 'A-Za-z'			upper- and lowercase letters to
# 'N-ZA-Mn-za-m'	their ROT13 equivalents
$ cat data.txt | tr 'A-Za-z' 'N-ZA-Mn-za-m'
The password is 5Te8Y4drgCRfCx8ugdwuEX8KFC6k2EUu
```

Password: `5Te8Y4drgCRfCx8ugdwuEX8KFC6k2EUu`

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
* `tr` translate or delete characters
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
[[Command piping]]