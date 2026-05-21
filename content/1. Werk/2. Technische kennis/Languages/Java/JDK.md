---
aliases:
  - JDK (Java Development Kit)
tags: Techniek
---
# [[Java]] Development Kit (JDK)
**Java Development Kit**, or **JDK**, is a package to develop programs for the Java Platform. It includes [[JRE]] to run the programs and tools for developers: Java compiler, debugger, archiver, documentation generator, etc.

At the compilation stage, compilers translate source code into `.class` files that contain bytecode and can be executed by [[JVM]]. Note that if you're using [[JVM]] languages other than Java, you will need to download compilers separately, as they are not bundled with [[JDK]].

In practice, programs often consist of multiple `.class` files packed together with an archiver tool into a single [[JAR|JAR (Java Archive)]] file. [[JRE]] can run the program packed into a [[JAR]] directly without extracting the archived files. The resulting file is more convenient to store and share over the network since the data is compressed.

Before Java 11, if you wanted only to run a Java program, JRE was enough for you. However, since Java 11 was released, for most JVM implementations JRE is no longer downloadable as a separate component. If you want to run programs in JVM 11 or newer, you have to install [[JDK]].

![[JDK.png]]