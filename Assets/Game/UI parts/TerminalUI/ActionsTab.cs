using System.Collections;
using System.Collections.Generic;
using Constants;
using UnityEngine;

public class ActionsTab : MonoBehaviour
{
    public enum ActiveTab {
        OperateTab, MailTab
    }

#pragma warning disable 649
    [SerializeField] bool activated;
    [SerializeField] Animator animator;
#pragma warning restore 649

    public void ActivateActionsTabAsOperate(bool isActivating) {
        animator.SetBool(triggers.ACTIONS_ACTIVE, isActivating);
        animator.SetBool(triggers.OPERATE_ACTIVE, isActivating);
    }

    public void ActivateActionsTabAsMail(bool isActivating) {
        animator.SetBool(triggers.ACTIONS_ACTIVE, isActivating);
    }

    public void ActivateOperateTab(bool isActivating) {
        animator.SetBool(triggers.OPERATE_ACTIVE, isActivating);
    }

    public void ActivateMailTab(bool isActivating) {
        animator.SetBool(triggers.MAIL_ACTIVE, isActivating);
    }

    public void DeactivateWholeActionsTab() {
        animator.SetBool(triggers.OPERATE_ACTIVE, false);
        animator.SetBool(triggers.MAIL_ACTIVE, false);
        animator.SetBool(triggers.ACTIONS_ACTIVE, false);
    }
}
