using System.Collections;
using System.Collections.Generic;
using Spine;
using Spine.Unity;
using Spine.Unity.AttachmentTools;
using UnityEngine;

public class ClickBehaviourScript : MonoBehaviour
{
    // own spine need equip sprite
    public List<Sprite> OwnSprites;
    
    // Boy spine need equip sprite
    public List<Sprite> BoySprites;

    // own spine
    public SkeletonAnimation OwnAnimation;

    // boy spine
    public SkeletonAnimation BoyAnimation;

    public void OnButtonClicked(int index)
    {
        // own spine
        ChangeSlotSkinSprite(OwnAnimation, "tuzi_fazhang", "tuzi_fazhang", OwnSprites[index], "default");
        
        // boy spine
        ChangeSlotSkinSprite(BoyAnimation, "gun", "gun", BoySprites[index], "base");
    }
    
    
    
    

   /// <summary>
   /// 修改spine中的slot中皮肤的精灵图片
   /// </summary>
   /// <param name="skeletonAnimation"><see cref="SkeletonAnimation" /> 对象</param>
   /// <param name="slotName">槽位名字</param>
   /// <param name="findSpriteName">槽位下要替换的精灵的名字</param>
   /// <param name="sprite">更换的图片</param>
   /// <param name="skinLayerName">皮肤所在层</param>
   public static void ChangeSlotSkinSprite(SkeletonAnimation skeletonAnimation, string slotName, string findSpriteName, Sprite sprite, string skinLayerName)
   {
       SpinChangeSlotSkinSprite(skeletonAnimation.Skeleton, skeletonAnimation.skeletonDataAsset, skeletonAnimation.AnimationState, slotName, findSpriteName, sprite, skinLayerName);
   }
   
   
   /// <summary>
   /// spine的Slot中皮肤图片的修改
   /// </summary>
   /// <param name="skeleton"><see cref="Skeleton" /> 对象</param>
   /// <param name="skeletonDataAsset">spine中skeletonDataAsset对象</param>
   /// <param name="animationState">spine中AnimationState对象</param>
   /// <param name="slotName">槽位名字</param>
   /// <param name="findSpriteName">槽位下要替换的精灵的名字</param>
   /// <param name="sprite">更换的图片</param>
   /// <param name="skinLayerName">皮肤所在层</param>
   private static void SpinChangeSlotSkinSprite(Skeleton skeleton, SkeletonDataAsset skeletonDataAsset, Spine.AnimationState animationState, string slotName, string findSpriteName,  Sprite sprite, string skinLayerName)
   {
       Attachment cloneAttachment;
       var skeletonData = skeletonDataAsset.GetSkeletonData(true);
       var skin = skeletonData.FindSkin(skinLayerName);
       var slotData = skeletonData.FindSlot(slotName);
       Attachment templateAttachment = skin.GetAttachment(slotData.Index, findSpriteName);
       cloneAttachment = templateAttachment.GetRemappedClone(sprite, templateAttachment.GetMaterial());
       skin.SetAttachment(slotData.Index, slotName, cloneAttachment);
       skeleton.SetSkin(skin);
       skeleton.SetSlotsToSetupPose();
       animationState.Apply(skeleton);
   }
    
    
    
}
