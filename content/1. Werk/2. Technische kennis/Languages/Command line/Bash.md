---
tags: Techniek
---
# Bash
Command line language for [[Linux]]-systems and (more or less) for [[PowerShell]]. 
https://replit.com/languages/bash

https://explainshell.com/

To make a file executable: 
```bash
chmod +x [filename]
```

## Commands

### File/directory operations
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
* `more` view file with pagination
	* while paused, you can use various commands
	* `v` opens a default text editor
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
* `chmod`change file mode bits

### Text manipulation
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
* `diff` compare files line by line
	* `--suppress-common-lines` do not output common lines
* `comm [opt] FILE1 FILE2` compare two sorted files line by line
	* `-1` suppress column 1 (lines unique to `FILE1`)
	* `-2` suppress column 2 (lines unique to `FILE2`)
	* `-3` suppress column 3 (lines in both files)
	* `--nocheck-order` do not check that the input is correctly sorted.
* `md5sum` compute and check MD5 message digest

### Compressions, archives and hexdumps
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

### Connections
* `ssh` secure shell to another computer
	* `[user]@[host]` connect to `[host]` as username `[user]`
	* `-p [port]` use this port instead of the default.
	* `-i [file]` identity file (private key) location
	* `'[command]'` you can add a command to execute once the connection is up, before automatic scripts are executed. 
* `telnet` user interface to the TELNET protocol
	* `open [host]` open a connection to the named host.
		* `- [port]` at this port number
	* `send [argument]``
* `nc` or `netcat` reads and writes data across network connection with TCP or UDP protocol. 
	* `-l` listen mode for inbound connections
	* `-p [port]` port number
	* `< [file]` redirect I/O to this file
* `openssl` cryptography toolkit implementing [[SSL]] and [[TLS]]
	* `s_client` connect to a remote host using SSL/TLS
		* `-connect [host]:[port]` specify host and optional port 
* `nmap` network exploration tool and security/port scanner
	* `-p [port ranges]` such as `-p31000-32000` 
* `bash`
* `screen`
* `tmux`
* `bg`
* `fg`
* `jobs`

### Scheduled tasks
* `cron`
* `crontab`
* `crontab(5)` (use "man 5 crontab" to access this)

### Miscellaneous
* Standard I/O types
	* `0` = standard input (stdin)
	* `1` = standard output (stdout)
	* `2` = standard error (stderr)

### [[Java]] commands
* `javac [program].java` compile sourcecode to bytecode
* `java [program].class` run bytecode in [[JVM]]
* `java [program].java` compile in-memory and run sourcecode (no `.class` file is made)