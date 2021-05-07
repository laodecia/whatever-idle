# whatever-idle


# Generic Purpose
What I'm trying to test/practice in this project is decoupling data and fast deployment. I'm getting my fast deployment through use of scriptable objects (I tend to just label them as "SO" from here out). I'm attempting to decouple by using events to broadcast and subscribe key events.

Currently two key events in my mind:
* A resource is produced
* Time has passed




# Time Related Part of the Project
There's a Timer UI class subscribing for a change in seconds to update a timer in the UI - currently just for testing and visual reference.
https://github.com/laodecia/whatever-idle/blob/35f093c84bb1b0c3e3f9a66ce732e29dc79de811/Whatever/Assets/Scripts/TimerUI.cs

There's a Time Manager class that is broadcasting 3 events:
  *One Second Changed
  *One Minute Changed
  *One Hour Changed
https://github.com/laodecia/whatever-idle/blob/35f093c84bb1b0c3e3f9a66ce732e29dc79de811/Whatever/Assets/Scripts/TimeManager.cs


The intent is only the Time Manager is ticking off - and everything that has a timer references off this time.
In addition the Time Manager has a time scale so I can affect how fast the ticks should feel.
So if I define that "Mining Gold" should have a time to produce of 10 seconds, it's getting passing time from the time manager, and relaying that to a local time of that "Mining Gold" Producer alone.
I am aware that all things subscribing to that time would be running on the same ticks, not truely independent to each producer.
If I wanted to halt time I could just change my time scale to 0 and all production would halt.




# Production Related Part of the Project
There are two Scriptable objects set up to the production of a resource.

### Producer SO - Used to create base stats about production
https://github.com/laodecia/whatever-idle/blob/35f093c84bb1b0c3e3f9a66ce732e29dc79de811/Whatever/Assets/Scripts/SOs/Producer.cs
* Right clicking in the editor under the Scriptable Objects Folder
  * Create > New Scriptable Object > Create New Producer Type
      
### Resource SO - Used to deploy a new type of resource and to pass what resource a producer would make
https://github.com/laodecia/whatever-idle/blob/35f093c84bb1b0c3e3f9a66ce732e29dc79de811/Whatever/Assets/Scripts/SOs/Resource.cs
* Right clicking in the editor under the Scriptable Objects Folder
  * Create > New Scriptable Object > Create New Resource Type
      
      
## Produce Resource class:
https://github.com/laodecia/whatever-idle/blob/35f093c84bb1b0c3e3f9a66ce732e29dc79de811/Whatever/Assets/Scripts/ProduceResource.cs
* Pulls in a Resource SO and a Produce SO
* Subscribes to when a second has passed from the time manager
* Every second calls the produce method that increments a local time and checks against the production time sourced from the SO
* Once something is produced a new event that something has been produced is broadcast.
* And some amount is added to the resource being produced


There's a simple prefab, ProducerGO, that at the parent level has a Produce Resource Script.
The button is unnecessary at the moment but will eventually be to purchase the producer - it also has a call to a Produce method in Produce Resource.
So to deploy a new production:
* Drop a "ProducerGO" prefab into the Scene > Canvas > Mid Display 
  * At the parent level of ProducerGo:
    * Add a SO Resource Type to the Produce Resource Script
    * Add a SO Producer Type to the Produce Resource Script
 


Normally I wouldn't have long comment sections, but I wanted to kind of write out some thoughts of what I wanted to do, or why I was doing it, or where I might be heading with it. I'll cover those in the actual review.
