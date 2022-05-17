/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
//using DG.Tweening;
using UnityEngine.EventSystems;
using UnityEngine.UI;


[RequireComponent(typeof(RectTransform)), ExecuteAlways]
public class Vertikal : UIBehaviour, ILayoutElement, ILayoutGroup
{
    [SerializeField] private Vector2 flexibleSize;
    [SerializeField] private Vector4 panding;
    [SerializeField] private int layotPriority;
    [SerializeField] private float spacing;


    private Vector2 minSize;
    private Vector2 preferredSize;
    private ChildData[] childrenData = Array.Empty<ChildData>();

    public float minWidth => minSize.x;
    public float minHeight => minSize.y;
    public float preferredWidth => preferredSize.x;
    public float preferredHeight => preferredSize.y;
    public float flexibleWidth => flexibleSize.x;
    public float flexibleHeight => flexibleSize.y;
    int ILayoutElement.layoutPriority => layotPriority;

    private void GatherChildren()
    {
        childrenData = transform
            .OfType<RectTransform>()
            .Select(MapToChildData)
            .ToArray();

            ChildData MapToChildData(RectTransform childTransform)
            {
            childTransform.TryGetComponent<ILayoutIgnorer>(out var ignorer);
            return new ChildData
            {
                Transform = childTransform,
                Ignorer = ignorer
            };
            }
    }
    protected override void OnEnable()
    {
        base.OnEnable();
        GatherChildren();
        SetDirty();
    }
    private void OnTransformChildrenChanged()
    {
        GatherChildren();
    }
    private void SetDirty()
    {
        if (!IsActive()) return;
        if (!CanvasUpdateRegistry.IsRebuildingLayout())
            LayoutRebuilder.MarkLayoutForRebuild((RectTransform)transform);
        else
            StartCoroutine(DelayedSetDirty((RectTransform)transform));
    }
    IEnumerator DelayedSetDirty(RectTransform rectTransform)
    {
        yield return null;
        LayoutRebuilder.MarkLayoutForRebuild(rectTransform);
    }
    protected override void OnValidate()
    {
        base.OnValidate();
        SetDirty();
    }
    protected override void OnRectTransformDimensionsChange()
    {
        base.OnRectTransformDimensionsChange();
        SetDirty();
    }
    protected override void OnDidApplyAnimationProperties()
    {
        base.OnDidApplyAnimationProperties();
        SetDirty();
    }
    public void CalculateLayoutInputHorizontal()
    {
        minSize.x = 0;
        preferredSize.x = 0;
        for (var index = 0; index < childrenData.Length; index++)
        {
            ref var childData = ref childrenData[index];
            if (childData.IsIgnored) continue;
            var childMinWidth = LayoutUtility.GetMinHeight(childData.Transform);
            var childPreferredWidth = LayoutUtility.GetPreferredHeight(childData.Transform);
            if (minSize.x < childMinWidth) minSize.x = childMinWidth;
            if (preferredSize.x < childPreferredWidth) preferredSize.x = childPreferredWidth;
        }

        minSize.x = panding.x + panding.z;
        preferredSize.x = panding.x + panding.z;
    }
    public void CalculateLayoutInputVertical()
    {
        minSize.y = 0;
        preferredSize.y = 0;
        for (var index = 0; index < childrenData.Length; index++)
        {
            ref var childData = ref childrenData[index];
            if (childData.IsIgnored) continue;
            var childMinHeight = LayoutUtility.GetMinHeight(childData.Transform);
            var childPreferredHeight = LayoutUtility.GetPreferredHeight(childData.Transform);
            minSize.y += childMinHeight + spacing;
            preferredSize.y += childPreferredHeight + spacing;
        }

        minSize.y = panding.y + panding.w - spacing;
        preferredSize.y = panding.y + panding.w - spacing;
    }
    public void SetLayoutHorizontal()
    {

    }
    public void SetLayoutVertical()
    {
        var size = ((RectTransform)transform).rect.size;
        var y = panding.y;
        for (var index = 0; index < childrenData.Length; index++)
        {
            ref var childData = ref childrenData[index];
            if (childData.IsIgnored) continue;
            var childMinHeight = LayoutUtility.GetMinHeight(childData.Transform);
            var childPreferredHeight = LayoutUtility.GetPreferredHeight(childData.Transform);

            childData.Size.x = size.x - panding.x - panding.z;
            childData.Size.y = childPreferredHeight > childMinHeight
                ? childPreferredHeight
                : childMinHeight;

            childData.Position.x = panding.x;
            childData.Position.y = -y;
            y += childData.Size.y + spacing;
        }
        ApplyChildrenSizes();
    }
    private void ApplyChildrenSizes()
    {
        for (var index = 0; index < childrenData.Length; index++)
        {
            ref var child = ref childrenData[index];
            if (child.IsIgnored) continue;

            child.Transform.sizeDelta = child.Size;
            child.Transform.anchoredPosition = child.Position;
        }
    }
}
*/

