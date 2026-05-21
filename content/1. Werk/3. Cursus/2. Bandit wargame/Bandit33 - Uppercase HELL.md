---
tags: Techniek
---
# Bandit Level 33
After all this `git` stuff its time for another escape. Good luck!

Commands you may need to solve this level:
sh, man

## Setup from [[Bandit32 - Push new file]]
```bash
ssh bandit32@bandit.labs.overthewire.org -p 2220
``` 

Password:
```
56a9bf19c63d650ce78e6ec0354ee45e
```

## Method
![[Bandit33.png]]

ARGH. 
```bash
>> ls
sh: 1: LS: not found
>> #
>> $
sh: 1: $: not found
>> %
sh: 1: %: not found
>> &
sh: 1: Syntax error: "&" unexpected
>> $0
$ 
# Oh thank fuck

$ ls
uppershell
# Nope, not touching that again!

$ cat /etc/bandit_pass/bandit33
c9c3199ddf4121b10cf581a98d51caee
```

Password: 
```
c9c3199ddf4121b10cf581a98d51caee
```

### See further
[[Bash]]