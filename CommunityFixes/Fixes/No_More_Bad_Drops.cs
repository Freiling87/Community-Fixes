using BepInEx.Logging;
using BTHarmonyUtils;
using BTHarmonyUtils.TranspilerUtils;
using HarmonyLib;
using JetBrains.Annotations;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace CommunityFixes
{
	[HarmonyPatch(typeof(ObjectReal))]
	static class No_More_Bad_Drops
	{
		private static readonly ManualLogSource logger = CFLogger.GetLogger();
		private static GameController GC => GameController.gameController;

		[HarmonyTargetMethod, UsedImplicitly]
		private static MethodInfo Find_MoveNext_MethodInfo() =>
			PatcherUtils.FindIEnumeratorMoveNext(AccessTools.Method(typeof(ObjectReal), "DestroyMe2"));

		[HarmonyTranspiler, UsedImplicitly]
		private static IEnumerable<CodeInstruction> FilterInvestigationTextFromSpilledItems(IEnumerable<CodeInstruction> codeInstructions)
		{
			List<CodeInstruction> instructions = codeInstructions.ToList();
			FieldInfo invItemList = AccessTools.DeclaredField(typeof(InvDatabase), nameof(InvDatabase.InvItemList));
			MethodInfo filteredList = AccessTools.DeclaredMethod(typeof(No_More_Bad_Drops), nameof(No_More_Bad_Drops.FilteredInvItemList));

			CodeReplacementPatch patch = new CodeReplacementPatch(
				pullNextLabelUp: false,
				expectedMatches: 1,
				prefixInstructions: new List<CodeInstruction>
				{
					new CodeInstruction(OpCodes.Ldfld, invItemList),
				},
				insertInstructions: new List<CodeInstruction>
				{
					new CodeInstruction(OpCodes.Call, filteredList)
				});

			patch.ApplySafe(instructions, logger);
			return instructions;
		}
		public static List<InvItem> FilteredInvItemList(List<InvItem> invItemList) =>
			invItemList.Where(invItem => !invItem.invItemName?.StartsWith("E_") ?? false).ToList();
	}
}
