---
aliases: [FIT (Framework for Integrated Testing)]
tags: Techniek
---
# Framework for Integrated Testing (FIT)
Fit ("Framework for Integrated Testing"), also often spelled [FIT](http://fit.c2.com/) is the engine that actually processes each FitNesse test table, using the [Fixture Code](http://docs.fitnesse.org/FitNesse.UserGuide.WritingAcceptanceTests.FixtureCode) referred to by that table. The idea of test tables and the set of [>Test Table Styles](http://docs.fitnesse.org/FitNesse.UserGuide.WritingAcceptanceTests.FitFramework.TestTableStyles) come from Fit. Examples of use can be found in the [Fixture Gallery](http://docs.fitnesse.org/FitNesse.UserGuide.FixtureGallery).  
  
FitNesse is an HTML and [wiki](http://wiki.org/wiki.cgi?WhatIsWiki) "front-end" to Fit. While Fit makes it possible to run test tables, it does not itself provide an easy means of creating those tables or displaying the results of those tests. This is where FitNesse comes in. FitNesse makes it _really easy_ to create, run, organize, annotate, and share Fit tests throughout a software development team.  
  
Interestingly both the wiki and Fit were developed by Ward Cunningham, and you can read about them both on Ward's [c2 wiki](http://fit.c2.com/).  
  
Throughout this [User Guide](http://docs.fitnesse.org/FitNesse.UserGuide), when we talk about how test tables are run, we often talk about Fit, since it is, in fact, doing the work. But for your purposes as a FitNesse user, Fit is just part of the magic: FitNesse hides Fit from you completely. You really don't need to worry about it at all.  
  
As we've seen, every FitNesse test table begins with a row that contains the classname of the [Fixture Code](http://docs.fitnesse.org/FitNesse.UserGuide.WritingAcceptanceTests.FixtureCode) that will interpret the rest of the table. The rest of the rows in a test table depend on which style of table and fixture we are using (each style of test table has its own style of fixture code).  
  
Here we point you to pages that describe each of the styles of FitNesse test table, and the fixture code used to interpret and run them as tests.

See further: [User Guide](http://docs.fitnesse.org/FitNesse.UserGuide.WritingAcceptanceTests.FitFramework) 