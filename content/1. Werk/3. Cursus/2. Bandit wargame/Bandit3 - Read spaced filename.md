---
tags: Techniek
---
# Bandit Level 3
The password for the next level is stored in a file called **spaces in this filename** located in the home directory

## Setup from [[Bandit2 - Read file at path]]
```bash
ssh bandit2@bandit.labs.overthewire.org -p 2220
``` 

Password: `CV1DtqXWVFXTvM2F0k09SHz0YwRINYA9`

## Method
```bash
$ ls
spaces in this filename

# Use autocomplete to avoid the issue
$ cat spaces\ in\ this\ filename 
UmHadQclWmgdLOKQ3YNgjWxGoRMb5luK

# Or use quotation marks around the filename
$ cat "spaces in this filename"
UmHadQclWmgdLOKQ3YNgjWxGoRMb5luK
```
Password: `UmHadQclWmgdLOKQ3YNgjWxGoRMb5luK`

### Commands
* `ssh` secure shell to another computer
	* `[user]@[host]` connect to `[host]` as username `[user]`
	* `-p [port]` use this port instead of the default.
* `ls` list directory contents
	* `-a` including hidden files
	* `-l` list on separate lines
* `cd` change directory
* `cat` (short for concatenate, aka print as string)
* `file` determine filetype
* `du` estimate fule space usage
* `find` search for file in directory hierarchy

### See further
[[Bash]]