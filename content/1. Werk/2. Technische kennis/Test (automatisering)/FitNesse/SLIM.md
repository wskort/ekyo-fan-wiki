---
aliases:
  - SLIM (Simple List Invocation Method)
tags: Techniek
---
# Simple List Invocation Method (SLIM)
Slim (Simple List Invocation Method) is an alternative to Fit. Rather than running all the HTML processing, comparisons, and colorizing in the System Under Test (SUT), Slim keeps all that behavior on in FitNesse. What executes in the SUT is a very tiny kernel that implements the [_Slim Protocol_](http://docs.fitnesse.org/FitNesse.UserGuide.WritingAcceptanceTests.SliM.SlimProtocol). This protocol is a bare bones RPC system that allows FitNesse to call functions in the SUT.  
  
This strategy has a number of advantages:  

-   The Slim protocol is very easy to port. Getting new platforms to use SLIM is a matter of a few hours of work.
-   All the features are on the FitNesse side, so test tables remain consistent regardless of the platform of the SUT.
-   Since HTML is not an intrinsic part of SLIM, new test syntaxes can be explored.

See further: [User Guide](http://docs.fitnesse.org/FitNesse.UserGuide.WritingAcceptanceTests.SliM) 