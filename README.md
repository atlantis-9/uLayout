# uLayout
**uLayout** is simple UI layout system designed as a drop-in replacement for Unity's `VerticalLayoutGroup` and `HorizontalLayoutGroup`, implementing a core subset of the *flexbox* spec from CSS.

Any flexbox rules that aren't present likely won't be added, as, in my opinion, they aren't needed and would simply bloat the package. I like my assets as lean and simple as possible. The one exception is `flex-grow`, which I do consider core functionality, but haven't yet decided on the best implementation, as it requires an extra layer of communication between the `Layout` and its children.

uLayout is designed with performance in mind (layout children are cached between hierarchy changes), but I haven't run any dedicated performance tests yet.

## Setup
uLayout requires there to be a `LayoutRoot` component at the top of the UI hierarchy. "Top" in this case is relative&mdash;as long as it's above every `Layout` object, you're good to go :) There's also nothing stopping you from using multiple `LayoutRoot` objects in the same scene.

uLayout also supports *TextMeshPro* `TMP_Text` objects, using the `LayoutText` component. This offers the same sizing options as the `Layout`, allowing text objects to resize depending on contents and font size.

If you want a specific element to be exluded from the layout (use *absolute* positioning, as they say in CSS), you can give it the `IgnoreLayout` component.

Further explanation and examples can be found in the sample scene at `Examples/LayoutDemo.unity`

## Component Settings
### Layout
- **Sizing X, Sizing Y** - `SizingMode`
  - **None:** Rect size is not controlled by the `Layout`
  - **Inherit:** Rect size is set to its parent size (per-axis)
  - **FitContent:** Rect is sized to fit around its children, taking into account padding and inner spacing
- **Padding (top, bottom, left, right)** - `float`\
Set a buffer width between each edge and the layout contents
- **Direction** - `LayoutDirection`
  - **Row:** Position children left-to-right
  - **Column:** Position children top-to-bottom
  - **RowReverse:** Position children right-to-left
  - **ColumnReverse:** Position children bottom-to-top
- **Justify Content** - `Justification`
  - **Start:** Align children to the start of the primary axis (depends on `Direction`: left for Row, top for Column, etc)
  - **Center:** Align children to the center of the primary axis
  - **End:** Align children to the end of the primary axis
  - **SpaceBetween:** Space children evenly across the primary axis
- **Align Content** - `Alignment`
  - **Start:** Align children to the start of the cross axis (depends on `Direction`: top for Row, left for Column, etc)
  - **Center:** Align children to the center of the cross axis
  - **End:** Align children to the end of the cross axis
- **Inner Spacing** - `float`\
Sets the gap between children on the primary layout axis. Does not work with `Justification.SpaceBetween` (layout will be wrong, just set to 0)

### LayoutText
- **Sizing X, Sizing Y** - `SizingMode`\
Same as `Layout` sizing, see above.

## Installation
uLayout can be installed from a `.unitypackage` file. Download the latest release from the Releases tab.

---

## Known Issues
- Console reports missing references on import - simply enter Play Mode once and it should fix itself (also you need the TextMeshPro assets)
- "**Inherit**" `SizingMode` doesn't take parent padding into account
- `SizingMode` does not include an equivalent for `flex-grow` CSS rule

