---
tags: Techniek
---
# FitNesse
[[FitNesse]] is a tool for specifying and verifying application acceptance criteria (requirements). It acts as a bridge between the different stakeholders (disciplines) in a software delivery process. Its wiki server makes it easy to document the software. Its test-execution capabilities allow you to verify the documentation against the software, ensuring the documentation remains up to date and the software is not facing regression.  
  
For this to work, the tests should be defined on a business level, in conjunction with business representatives. They are basically business requirements, laid out in a way easy to understand by all stakeholders. When your requirements are unambiguous, they can be automatically verified with your application.  
  
To make it easy for all stakeholders to interact with [[FitNesse]], requirements can be created and edited through the web browser. It's a wiki! By writing specifications (also known as [Acceptance Tests](http://docs.fitnesse.org/FitNesse.UserGuide.AcceptanceTests)), you can create a common understanding among the team (coders and non-coders). This helps tremendously in [delivering the right system](http://docs.fitnesse.org/FitNesse.UserGuide.DeliveringTheRightSystem). Specifications can be written in wiki syntax or in a rich text editor, so no knowledge of the wiki syntax is required.  
  
Because the specifications can actually be executed, [[FitNesse]] provides a method to demonstrate even to non-coders that the application works as designed. This can prevent problems leading to [Project Death by Requirements](http://docs.fitnesse.org/FitNesse.UserGuide.ProjectDeathByRequirements). The goal is for [[FitNesse]] to operate at a level just _below_ the user interface level, demonstrating that, given various inputs to your application, the correct results are computed. In a sense, you could consider it an alternative user interface for the application.

[[FitNesse]] provides two test systems out-of-the-box: [[FIT|FIT (Framework for Integrated Testing)]] and [[SLIM|SLIM (Simple List Invocation Method)]] 

See further: [User Guide](http://docs.fitnesse.org/FitNesse.UserGuide) 