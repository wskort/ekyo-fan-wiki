---
tags: Techniek
---
# Bandit Level 0

https://overthewire.org/wargames/bandit/

The goal of this level is for you to log into the game using SSH. The host to which you need to connect is **bandit.labs.overthewire.org**, on port 2220. The username is **bandit0** and the password is **bandit0**. 

## Method

```bash
ssh bandit0@bandit.labs.overthewire.org -p 2220
``` 

Password: `bandit0`

### Commands
* `ssh` secure shell to another computer
	* `[user]@[host]` connect to `[host]` as username `[user]`
	* `-p [port]` use this port instead of the default.

### See further
[[SSH tool]]
[[Bash]] 