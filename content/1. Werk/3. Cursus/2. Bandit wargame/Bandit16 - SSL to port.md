---
tags: Techniek
---
# Bandit Level 16
The password for the next level can be retrieved by submitting the password of the current level to **port 30001 on localhost** using SSL encryption.

**Helpful note: Getting “HEARTBEATING” and “Read R BLOCK”? Use -ign\_eof and read the “CONNECTED COMMANDS” section in the manpage. Next to ‘R’ and ‘Q’, the ‘B’ command also works in this version of that command…**

## Setup from [[Bandit15 - TELNET to port]]
```bash
ssh bandit15@bandit.labs.overthewire.org -p 2220
``` 

Password: `BfMYroe26WYalil77FoDi9qh59eK5xNr`

## Method
```bash
# openssl		use the openssl tool
# s_client		to create an SSL/TLS connection
# -connect		now open a connection
# localhost		to this host
# :30001		on this port
$ openssl s_client -connect localhost:30001

CONNECTED(00000003)
depth=0 CN = localhost
verify error:num=18:self signed certificate
verify return:1
depth=0 CN = localhost
verify return:1
---
Certificate chain
 0 s:/CN=localhost
   i:/CN=localhost
---
Server certificate
-----BEGIN CERTIFICATE-----
MIICBjCCAW+gAwIBAgIEPksiGTANBgkqhkiG9w0BAQUFADAUMRIwEAYDVQQDDAls
b2NhbGhvc3QwHhcNMjEwMTAzMTkzODIzWhcNMjIwMTAzMTkzODIzWjAUMRIwEAYD
VQQDDAlsb2NhbGhvc3QwgZ8wDQYJKoZIhvcNAQEBBQADgY0AMIGJAoGBAM2B6gJt
YTxcQPphtWBuM1ge8cuuvdaD4jc0LZ4PMQzqxH3xnw1pRWIJPUXHxoqbC4xxXNLk
6zR0CrLH2AfPraS3gMPy7MtmDoGpNea3XJ/t1jkcxSNPsTfoGjpHhJ686lmQLsO4
CAsLHYupe/dFwHwQYjfmp8M3rpWm8jv3kzK9AgMBAAGjZTBjMBQGA1UdEQQNMAuC
CWxvY2FsaG9zdDBLBglghkgBhvhCAQ0EPhY8QXV0b21hdGljYWxseSBnZW5lcmF0
ZWQgYnkgTmNhdC4gU2VlIGh0dHBzOi8vbm1hcC5vcmcvbmNhdC8uMA0GCSqGSIb3
DQEBBQUAA4GBAFEvYhX6w87jWnKLpx9iSVhI1cBxNS5tzzOT+XzjIiZF5v78QJcp
I7h4z4ncZVOJGazdArF+6/B2uHFT7+QKVmQNbnX/wSAEJM0Mvp9qHOlMYaRvwP34
BRXc6VqbVQ4EbPTU5UcN1Yp7lLJ4DuNYfChFpX0xCTkhIvGWqXkGecyP
-----END CERTIFICATE-----
subject=/CN=localhost
issuer=/CN=localhost
---
No client certificate CA names sent
Peer signing digest: SHA512
Server Temp Key: X25519, 253 bits
---
SSL handshake has read 1019 bytes and written 269 bytes
Verification error: self signed certificate
---
New, TLSv1.2, Cipher is ECDHE-RSA-AES256-GCM-SHA384
Server public key is 1024 bit
Secure Renegotiation IS supported
Compression: NONE
Expansion: NONE
No ALPN negotiated
SSL-Session:
    Protocol  : TLSv1.2
    Cipher    : ECDHE-RSA-AES256-GCM-SHA384
    Session-ID: 87595EB28385FA8E5C05261F6BDED7E2A43464E76A48239D3A509625C5CF49A3
    Session-ID-ctx: 
    Master-Key: 54ECCB27540734398404C270453C421C2F5C6946AEE82FC302B8EA5B19463636EBB5007A1C7603642504EB0A1A42C715
    PSK identity: None
    PSK identity hint: None
    SRP username: None
    TLS session ticket lifetime hint: 7200 (seconds)
    TLS session ticket:
    0000 - a9 48 f8 cd 59 86 5a b6-19 9c 9f f8 42 95 26 f2   .H..Y.Z.....B.&.
    0010 - ae 56 e8 9d c7 89 03 72-68 3f 52 9d df 8d 11 93   .V.....rh?R.....
    0020 - 83 cf b7 96 1c fb 73 d2-0b 37 18 74 d6 02 e9 fb   ......s..7.t....
    0030 - b9 6d c7 ca 54 4e 3d 0e-34 03 47 17 56 72 aa 67   .m..TN=.4.G.Vr.g
    0040 - fa c0 77 11 d2 52 9b a0-fe 4b f6 9f 46 ed 55 c7   ..w..R...K..F.U.
    0050 - 89 3e a2 c0 86 2f 0e 65-ee f2 8a 0e 1b 38 84 8a   .>.../.e.....8..
    0060 - 42 98 bb 0f a0 f8 9f ef-a0 5d 3c e0 d6 7f b4 a8   B........]<.....
    0070 - 99 af f6 31 b3 4a ad ec-14 29 fa 0e ae 1d 19 fa   ...1.J...)......
    0080 - 32 e9 ee 92 38 b7 68 a3-95 54 1d a0 7b 09 59 1f   2...8.h..T..{.Y.
    0090 - 21 50 2a 4f df ec 1e e9-0a fa d5 6d 56 b3 79 91   !P*O.......mV.y.

    Start Time: 1614267725
    Timeout   : 7200 (sec)
    Verify return code: 18 (self signed certificate)
    Extended master secret: yes
---

# Okay, now I can input the password.
BfMYroe26WYalil77FoDi9qh59eK5xNr
Correct!
cluFn7wTiGryunymYOu4RcffSxQluehd

closed

```

Password: `cluFn7wTiGryunymYOu4RcffSxQluehd`

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
	* `s_client` connect to a remote host using SSL/TLS
		* `-connect [host]:[port]` specify host and optional port 
* `nmap`

#### Miscellaneous
* Standard I/O types
	* `0` = standard input (stdin)
	* `1` = standard output (stdout)
	* `2` = standard error (stderr)

### See further
[[Bash]]
[[SSL&TLS connection]]