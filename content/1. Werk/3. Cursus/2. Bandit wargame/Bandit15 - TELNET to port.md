---
tags: Techniek
---
# Bandit Level 15
The password for the next level can be retrieved by submitting the password of the current level to **port 30000 on localhost**.

## Setup from [[Bandit14 - Use private key]]
```bash
ssh bandit14@bandit.labs.overthewire.org -p 2220
``` 

Password: `4wcYUJFw0k0XLShlDzztnTBHiqxU3b3e`

## Method
```bash
# telnet		connect using the TELNET protocol 
# localhost		to the localhost
# 30000			on port 30000
$ telnet localhost 30000
Trying 127.0.0.1...
Connected to localhost.
Escape character is '^]'.

4wcYUJFw0k0XLShlDzztnTBHiqxU3b3e
Correct!
BfMYroe26WYalil77FoDi9qh59eK5xNr

Connection closed by foreign host.
```

Password: `BfMYroe26WYalil77FoDi9qh59eK5xNr`

### Commands

#### File/directory operations
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
* `mkdir` make directory
* `cp` copy files and directories
* `mv` move (rename) file

#### Text manipulation
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

#### Compressions, archives and hexdumps
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

#### Connections
* `ssh` secure shell to another computer
	* `[user]@[host]` connect to `[host]` as username `[user]`
	* `-p [port]` use this port instead of the default.
	* `-i [file]` identity file (private key) location
* `telnet` user interface to the TELNET protocol
	* `open [host]` open a connection to the named host.
		* `- [port]` at this port number
	* `send [argument]``
* `nc`
* `openssl`
* `s_client`
* `nmap`

#### Miscellaneous
* Standard I/O types
	* `0` = standard input (stdin)
	* `1` = standard output (stdout)
	* `2` = standard error (stderr)

### See further
[[Bash]]
[[TELNET]]