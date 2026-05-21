---
tags: Techniek
---
# Bandit Level 27
Good job getting a shell! Now hurry and grab the password for bandit27!

Commands you may need to solve this level:
ls

## Setup from [[Bandit26 - Abusing 'more']]
```bash
ssh bandit26@bandit.labs.overthewire.org -p 2220
``` 

Password:
```
5czgV9L3Xx8JPOyRbXh6lQbmIOWvPT6Z
```

## Method
Remember to set your terminal window to fewer than 6 lines to avoid the connection immediately closing. Use `v` to open the editor. 

In the editor, you can run commands by typing `:!command [command]`. 

```bash
# Let's look around...
:!command ls
bandit27-do  text.txt

# Alright, what is this bandit27-do?
:!command ./bandit27-do
Run a command as another user.
  Example: ./bandit27-do id
# ... well, don't mind if I do!

:!command ./bandit27-do cat /etc/bandit_pass/bandit27
3ba3118a22e93127a4ed485be72ef5ea
```

Password: 
```
3ba3118a22e93127a4ed485be72ef5ea
```

### See further
[[Bash]]