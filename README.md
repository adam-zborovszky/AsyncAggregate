# AsyncAggregate

AsyncAggregate provides two classes to decribe complex systems, what can be modeled by a collection of nested objects.
These classes aim to define the way, how one root-object can be unfolded to a collection sub-elements recursively.

The classes inherited from "Component" class (only) are the final atomic builder blocks of these collections. 
The classes inherited from "Assembly" class have a factory-like functionality to unfold themselves to a sub-collection of multiple items and sub-assemblies.

The model allows to build the final collection of items on a way, where in an assembly only the next level is defined. This definition can be dynamic, and dependent on the assembly object parameters. 

In addition to the dynamic building, the unfolding function can return multiple versions of object collections, where the optimal version can be selected one layer higher - depending on a cost parameter of the versions. - Question: is it necessary to make the cost parameter complex (containing multiple factors intead of one number)?
