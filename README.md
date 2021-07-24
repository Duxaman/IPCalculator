# IP Calculator

## Overview

GUI based IPv4 calculator with tree representation of networks.

![overview](https://user-images.githubusercontent.com/15687222/126867797-88040bc7-0e2e-4027-bf07-f7054060ba80.png)


## Features
- Get information about desired subnet
- Divide current network into subnets:

	To do this enter the root network, specify desired amount of hosts for each subnet and it's color inside net tree.
    Click divide to calculate all subnets and get it's tree representation 
    
    ![MainFeature](https://user-images.githubusercontent.com/15687222/126867810-07a12523-6051-4441-9ce1-d17cd175e3d0.gif)

    
- Aggregate and clear nodes:

	If you wish to change current layout of network tree you can aggregate all networks within a node and its children
    using context menu.
    
    After that you can change parameters of aggregated networks if needed and redivide them in another node.
    Nodes also can be cleared without aggregation
    
    ![AggregateAndDeleteFeature](https://user-images.githubusercontent.com/15687222/126867821-6899cd0f-2b84-4807-9c7e-235c13ea3383.gif)

    
- Save your network trees with all summary information in flexible JSON format to work with them later

    ![SaveFeature](https://user-images.githubusercontent.com/15687222/126867827-5a8c567f-6632-4cd4-9a3f-83a9a268e04f.gif)


## Requirements
- .NET Framework 4.5.1
-  Windows
