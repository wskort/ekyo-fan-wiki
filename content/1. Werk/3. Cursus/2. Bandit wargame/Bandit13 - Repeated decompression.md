---
tags: Techniek
---
# Bandit Level 13
The password for the next level is stored in the file **data.txt**, which is a hexdump of a file that has been repeatedly compressed. For this level it may be useful to create a directory under /tmp in which you can work using mkdir. For example: mkdir /tmp/myname123. Then copy the datafile using cp, and rename it using mv (read the manpages!)

## Setup from [[Bandit12 - Caesar rotation]]
```bash
ssh bandit12@bandit.labs.overthewire.org -p 2220
``` 

Password: `5Te8Y4drgCRfCx8ugdwuEX8KFC6k2EUu`

## Method
```bash
# xxd					Hexdump manipulation
# -r					revert
# data.txt				from this file
# /tmp/Willeke123		to this (temporary) file
$ xxd -r data.txt /tmp/Willeke123

# Identify filetype of new file
$ file /tmp/Willeke123
/tmp/Willeke123: gzip compressed data, was "data2.bin", last modified: Thu May  7 18:14:30 2020, max compression, from Unix

# To decompress the file, I need to correct the file suffix.
# mv					Move (in this case, rename)
# /tmp/Willeke123		This file
# /tmp/Willeke123.gz	To this file
$ mv /tmp/Willeke123 /tmp/Willeke123.gz

# Now decompress the gzip
$ gunzip /tmp/Willeke123.gz

# Identify filetype of new file
$ file /tmp/Willeke123
/tmp/Willeke123: bzip2 compressed data, block size = 900k

# Alright, decompress with bzip2 flavour!
$ bzip2 -d /tmp/Willeke123
bzip2: Can't guess original name for /tmp/Willeke123 -- using /tmp/Willeke123.out
# Uh, sure. Thanks.

# So what's this new file?
$ file /tmp/Willeke123.out
/tmp/Willeke123.out: gzip compressed data, was "data4.bin", last modified: Thu May  7 18:14:30 2020, max compression, from Unix

# Cool. Make it a .gz, will ya?
$ mv /tmp/Willeke123.out /tmp/Willeke123.gz

# And decompress it, gzip style.
$ gzip -d /tmp/Willeke123.gz

# Identify filetype of new file
$ file /tmp/Willeke123
/tmp/Willeke123: POSIX tar archive (GNU)
# Of course it is. 

# First, we need to make a directory. 
$ mkdir /tmp/Willeke/

# tar					Use the tar archive utility
# -x					to extract
# -f /tmp/Willeke123	everything from this archive file
# -C /tmp/Willeke/		to this folder
$ tar -xf /tmp/Willeke123 -C /tmp/Willeke/

# Identify new file...
$ file /tmp/Willeke/data5.bin
/tmp/Willeke/data5.bin: POSIX tar archive (GNU)

# tar						Use the tar archive utility
# -x						to extract
# -f /tmp/Willeke/data5.bin	everything from here
# -C /tmp/Willeke/			to this folder
$ tar -xf /tmp/Willeke123 -C /tmp/Willeke

# Identify new file...
$ file /tmp/Willeke/data6.bin
/tmp/Willeke/data6.bin: bzip2 compressed data, block size = 900k

# Gimme. 
$ bzip2 -d /tmp/Willeke/data6.bin
bzip2: Can't guess original name for /tmp/Willeke/data6.bin -- using /tmp/Willeke/data6.bin.out

# Identify.
$ file /tmp/Willeke/data6.bin.out
/tmp/Willeke/data6.bin.out: POSIX tar archive (GNU)

# Gimme.
$ tar -xf /tmp/Willeke/data6.bin.out -C /tmp/Willeke/

# Identify.
$ file /tmp/Willeke/data8.bin
/tmp/Willeke/data8.bin: gzip compressed data, was "data9.bin", last modified: Thu May  7 18:14:30 2020, max compression, from Unix

# Gimme.
$ mv /tmp/Willeke/data8.bin /tmp/Willeke/data8.gz
$ gzip -d /tmp/Willeke/data8.gz

# Identify.
$ file /tmp/Willeke/data8
/tmp/Willeke/data8: ASCII text

# GOOOOOOAAAAAAL
$ cat /tmp/Willeke/data8
The password is 8ZjyCRiBWFYkneahHwxCv3wb2a1ORpYL
```

Password: `8ZjyCRiBWFYkneahHwxCv3wb2a1ORpYL`

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
	* `-n [x]` only strings of at least `x` characters long
* `base64 [option] [file]` encode or decode file or text.
	* `-d` decode data
* `tr` translate or delete characters
* `tar` an archiving utility
		* `-t` or `--list` list the contents of an archive
		* `-x` or `--extract` or `--get` extract files
		* `-f [archive]` the tar archive location
* `gzip` compress or expand files, gzip flavour.
	* `-d` decompress
* `bzip2` compress or expand files, bzip2 flavour.
	* `-d` decompress
* `xxd` make or reverse a hexdump
	* `-r` revert
* `mkdir` make directory
* `cp` copy files and directories
* `mv` move (rename) file

* Standard I/O types
	* `0` = standard input (stdin)
	* `1` = standard output (stdout)
	* `2` = standard error (stderr)

### See further
[[Bash]]
[[Hexdump]]
[[Compressing and decompressing files]]
[[Archive]]