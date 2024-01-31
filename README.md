# AsyncAggregate

AsyncAggregate class can be used to define a structure, what can be described by the composite pattern. 
Beyond this data structure two addtional functionality is provided: 
- we can encapsulate the logic, what can detail the sub-components of the upper level component (assembly),
- and we can work out multiple configurations of the subcomponents, and when this structure has detailed enough to evaluate, then we can select the configuration (version) which serves better our needs (i.e. has higher scores).

The classes inherited from "Component" class are the final atomic builder blocks of these collections. 
The classes inherited from "Assembly" class have a factory-like functionality and can unfold itself to a sub-collection of multiple items and/or sub-assemblies.

This model allows to build the final structure of lowest level components - starting from one, top level assembly. This can happen on a way, where in an assembly the rule-set tells us how to select and setup the sub-components, and these rules may depend on the assembly parameters. This definition allows dynamic and flexible unfolding of an assebly.

Where to use:
- if the unfolding process (i.e. the sub-components of a structure) can't be selected along static decisions, but the selected solution depends on earlier decisions, then in this structure we can carry the required information of earlier decision to lower levels, and consider them in those decisions
- also when multiple solutions are possible to resolve a certain level question (i.e. different configurations are available), and we can't decide on that level due to the lack of lower level details, then by unfolding different versions can supply this information for the decision. Then one version can be kept, the other(s) are dropped.


Question: is it necessary to make the cost parameter complex (containing multiple factors intead of one number)?
