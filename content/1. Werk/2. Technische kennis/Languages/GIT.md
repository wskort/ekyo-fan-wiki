---
tags: Techniek
---
# Git
## Start a working area
* `clone` is copy a repository from the *origin*
* `init` create an empty Git repository

## Work on the current change
* `add` add file contents to the index
* `mv` move or rename a file, directory or symlink
* `reset` reset current HEAD to specified state
* `rm` remove files from working tree & index

## Examine history & state
* `bisect` use binary search to find the commit that introduced a bug
* `grep` print lines matching a pattern
* `log` show commit logs
* `show` show various types of objects
* `status` show working tree status

## Grow, mark and tweak your common history
* `branch` list, create or delete branches
	* `-a` list all local *and* remote branches
* `checkout <branchname>` checks out a specific branch to *local git*
* `commit` commit the files on your *local git*
	* `-m <comment>` adds a commit message (do this!)
* `diff` shows changes between commits, commit & working tree, etc.
* `merge` join two or more development histories together
* `rebase` reapply commits on top of other base tip
* `tag` create, list, delete or verify a tag object signed with GPG

## Collaborate
* `fetch` download objects and refs from another repository
* `push` pushes your *local git* to the *origin*
* `pull` (use from anywhere in the git directory) = update the repository from *origin*


[[Bash]]