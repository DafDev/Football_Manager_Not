# Football Manager Not
A tutorial following the one and only Coding militia that is a sport meetings schedumer
## Overview

### Concepts

+ Users:  well… this one is unexpected right? 😆
+ Groups: groups of friends that gather to play
+ Players: players are a different concept than a user to allow for groups of people where not everyone wants to use the application, but the users who want to can still manage everything even if there’s someone who’s not a registered user
+ Match/event/game:represents the specific event that has/is/will happen
+ Teams: the teams that play the match:this may very well be something fixed, but also something scoped to a match, where the teams are defined each time
+ Statistics: something interesting is to keep statistics os the various matches, like match scores, goal/point/other scorers, fouls, etc

### Desired features
While writing down the concepts, the desired features started to come to mind (along with some components that’ll be written down in the next section):

+ Create/manage users
	+ Define email, name, nickname, profile picture, …
	+ Communication
	+ Send emails, notifications, …
	+ Manage preferences
	+ Create/manage groups
	+ Invite users
	+ Create players
	+ Associate players with users
	+ Set a specific sport for the group
…
+ Matches
	+ Schedule
	+ Manage information
		+ When 
		+ Where
		+ Players involved
		+ Teams chosen …
	+ Add events
		+ Goal scored 
		+ Foul suffered 
		+ … (more and sport dependent)
	+ Live
		+ Add match events during the match  
		+ See the stats evolve realtime

### Components

Ok, with the concepts and desired features laid out as best as possible for this kind of project (if a business analyst gave something like this to one of us, we would probably be enraged 😝) we can start to picture our over-engineered system, where we try to fit in every possible hipster technology… and as this is that kind of project, that’ll be exactly what’ll happen!

The following is something of the sort of a very high level architecture. It’ll most certainly change along the way (for the best hopefully) but I think can summarize the initial ideas.


We can see basically an organization of the various components, where even if we’re over-engineering the solution, we don’t want the components to be like CRUD services, but be as much as possible self contained services that can implement a specific feature set.

With this in mind we have:

+ Users: to handle registration, authentication and other user management requirements
+ GroupManagement: to handle everything group related, from associating users to managing players.
+ Communication: to handle all communication requirements, including the user’s communication preferences.
+ Matches: to handle everything match specific, like when and where, scores, match events and more, except the live part.
+ LiveMatches: will probably be separated from the main matches component as it’ll have the realtime requirement and maybe useful to be isolated.
+ Statistics: this will be a central place to handle all statistics, even if they originally come from the match events:we’ll see in the long run how (and if we should) orchestrate this service with the matches one.