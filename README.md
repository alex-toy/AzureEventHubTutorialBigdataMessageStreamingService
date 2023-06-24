# Azure Event Hub Tutorial | Big data message streaming service

*Azure Event Hubs* is a highly scalable big data event processing service capable of processing millions of events per second. in this project will study *Event Hub* basics, partitions, namespaces, shared access signatures, even hubs, consumer groups.


## Event Hub

### Create Event Hub

- create a namespace
<img src="/pictures/event_hub.png" title="event hub"  width="500">

- create an *Event Hub*
<img src="/pictures/event_hub2.png" title="event hub"  width="500">

- create .NET app for sender and receiver

- create a send access policy for the sender and use the connection string in the app. Do the same for the receiver.
<img src="/pictures/event_hub3.png" title="event hub"  width="900">

- run the send app
<img src="/pictures/event_hub4.png" title="event hub"  width="900">

### Logic App

- create a *Logic App*
<img src="/pictures/logic_app.png" title="logic app"  width="500">

- add a *Workflow*
<img src="/pictures/workflow.png" title="workflow"  width="900">

- in the *Designer* section, choose *http request received*
<img src="/pictures/workflow2.png" title="workflow"  width="900">

- choose *event hub connector*, then *send event*
<img src="/pictures/workflow3.png" title="workflow"  width="900">

### Consumer Group

- add a consumer group
<img src="/pictures/consumer_group.png" title="consumer group"  width="900">

- run the receiver app
<img src="/pictures/consumer_group2.png" title="consumer group"  width="900">
