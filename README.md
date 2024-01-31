# AsyncAggregate

AsyncAggregate class can be used to define a structure, what can be described by the composite pattern. 

Beyond the composite pattern two additional functionality is provided: 
- we can encapsulate the logic, what can detail the sub-components of the upper level component (assembly),
- and we can work out multiple configurations of the subcomponents, and when this structure has detailed enough to evaluate, then we can select the configuration (version) which serves better our needs (i.e. has higher scores).

This model allows to build the final structure of lowest level components - starting from one, top level assembly. This can happen on a way, where in an assembly the rule-set tells us how to select and setup the sub-components, and these rules may depend on the assembly parameters. This definition allows dynamic and flexible unfolding of an assembly.

The classes inherited from "Component" class - if it stands on top of the structure - represent the starting assembly, what we aim to detail to lowest level components. Otherwise - in lower levels - it represents the selected component of the earlier decision. If this class is not an assembly at the same time, then we consider it as a final selected entity for the desired purpose. 
The classes inherited from "Assembly" class have a factory-like functionality and can unfold themselves to a sub-collection of multiple components and/or sub-assemblies.

Where to use:
- if the unfolding process (i.e. the selection of sub-components of a structure) can't be selected by parameterless (static) decisions, but the selected solution depends on earlier decisions, then this structure can carry the required information to lower levels.
- also when multiple solutions are possible to resolve a certain level question (i.e. different configurations are available), and we can't decide on that level due to the lack of lower level details, then by unfolding different versions can supply this information for the decision. Then one version can be kept, the other(s) are dropped.


Question: is it necessary to make the cost parameter complex (containing multiple factors intead of one number)?
