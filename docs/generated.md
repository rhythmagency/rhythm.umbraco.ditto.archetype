# Rhythm.Umbraco.Ditto.Archetype

<table>
<tbody>
<tr>
<td><a href="#dittoarchetypeattribute">DittoArchetypeAttribute</a></td>
<td><a href="#dittomixedarchetypeattribute">DittoMixedArchetypeAttribute</a></td>
</tr>
</tbody>
</table>


## DittoArchetypeAttribute

Allows for mapping of Archetype properties.

#### Remarks

Snagged from: https://github.com/leekelleher/umbraco-ditto-labs/blob/develop/src/Our.Umbraco.Ditto.Archetype/ComponentModel/Processors/DittoArchetypeAttribute.cs

### Constructor

Default constructor.

### Constructor(propertyName, altPropertyName, recursive, defaultValue)

Full constructor.

| Name | Description |
| ---- | ----------- |
| propertyName | *System.String*<br>The name of the property. |
| altPropertyName | *System.String*<br>The alternate property name. |
| recursive | *System.Boolean*<br>Map recursively? |
| defaultValue | *System.Object*<br>The default value. |

### ProcessValue

Process the value.

#### Returns

The processed value.


## DittoMixedArchetypeAttribute

This multi-processor combines the Archetype and DocTypeFactory processors to allow for both of those processors to be run with this single unified processor rather than having to specify the other two.

#### Remarks

This can be used when you have an Umbraco property that is an Archetype that allows for multiple items and multiple fieldset types (e.g., a widget collection).

### Constructor

Default constructor.

### GetProcessors

Returns the processors that should be run whenever this multi-processor is used.

#### Returns

The collection of processors to run.
