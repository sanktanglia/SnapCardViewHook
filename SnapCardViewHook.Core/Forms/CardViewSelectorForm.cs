using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using IL2CppApi.Wrappers;
using SnapCardViewHook.Core.IL2Cpp;
using SnapCardViewHook.Core.Wrappers;

namespace SnapCardViewHook.Core.Forms
{
    public partial class CardViewSelectorForm : Form
    {
        private Dictionary<string, IL2CppFieldInfoWrapper> _variantList;
        private Dictionary<string, IL2CppFieldInfoWrapper> _surfaceEffectList;
        private Dictionary<string, IL2CppFieldInfoWrapper> _revealEffectList;

        public CardViewSelectorForm()
        {
            InitializeComponent();
        }

        private void CardViewSelectorForm_Load(object sender, EventArgs e)
        {
            SnapTypeDataCollector.EnsureLoaded();

            _variantList = SnapTypeDataCollector.ArtVariantDef_Id_Fields.ToDictionary(f => f.Name);
            _surfaceEffectList = SnapTypeDataCollector.SurfaceEffectDef_Id_Fields.ToDictionary(f => f.Name);
            _revealEffectList = SnapTypeDataCollector.CardRevealEffectDef_Id_Fields.ToDictionary(f => f.Name);

            surfaceEffectBox.Items.AddRange(_surfaceEffectList.Keys.ToArray());
            revealEffectBox.Items.AddRange(_revealEffectList.Keys.ToArray());
            variantBox.Items.AddRange(_variantList.Keys.ToArray());


            SnapTypeDataCollector.CardViewInitializeHookOverride = CardViewInitOverride;
        }

        public void CardViewInitOverride(
            IntPtr thisPr, IntPtr cardDef, int cost, int power, int rarity,
            IntPtr borderDefId, IntPtr artVariantDefId, IntPtr surfaceEffectDefId,
            IntPtr cardRevealEffectDefId, int cardRevealEffectType, bool showRevealEffectOnStart,
            int logoEffectId, int cardBackDefId, bool isMorph)
        {
            artVariantDefId = GetVariantOverride(artVariantDefId, cardDef);
            surfaceEffectDefId = GetSurfaceEffectOverride(surfaceEffectDefId);
            cardRevealEffectDefId = GetRevealEffectOverride(cardRevealEffectDefId);

            if (force3DCheckbox.Checked)
                rarity = 7;

            SnapTypeDataCollector.CardViewInitializeOriginal(thisPr, cardDef, cost, power, rarity, borderDefId, artVariantDefId,
                surfaceEffectDefId, cardRevealEffectDefId, cardRevealEffectType, showRevealEffectOnStart, logoEffectId,
                cardBackDefId, isMorph);
        }

        private unsafe IntPtr GetVariantOverride(IntPtr original, IntPtr cardDef)
        {
            if (!overrideVariantCheckBox.Checked || variantBox.SelectedItem == null)
                return original;

            var variantDefPtr = IL2CppHelper.GetStaticFieldValue(_variantList[variantBox.SelectedItem.ToString()].Ptr);

            if (ensureVariantMatchCheckbox.Checked)
            {
                var cardToArtVariantDef = SnapTypeDataCollector.CardToArtVariantDefList_Find(variantDefPtr);
                var variantCardDef = *(int*)(cardToArtVariantDef +
                                              SnapTypeDataCollector.CardToArtVariantDef_CardDefId_Field_Offset);

                if (variantCardDef != new CardDefWrapper(cardDef).CardDefId)
                    return original;
            }

            return variantDefPtr;
        }

        private IntPtr GetSurfaceEffectOverride(IntPtr original)
        {
            if (!overrideSurfaceEffectCheckBox.Checked || surfaceEffectBox.SelectedItem == null)
                return original;

            return IL2CppHelper.GetStaticFieldValue(_surfaceEffectList[surfaceEffectBox.SelectedItem.ToString()].Ptr);
        }

        private IntPtr GetRevealEffectOverride(IntPtr original)
        {
            if (!overrideRevealEffectCheckBox.Checked || revealEffectBox.SelectedItem == null)
                return original;

            return IL2CppHelper.GetStaticFieldValue(_revealEffectList[revealEffectBox.SelectedItem.ToString()].Ptr);
        }

        private void CardViewSelectorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SnapTypeDataCollector.CardViewInitializeHookOverride = null;
        }
    }
}
