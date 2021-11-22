using System;
using System.Collections;
using Attributes;
using Extensions;
using Game.CombinedTilesSimple.SlidingDoors;
using ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Game.UIParts.Terminal.TerminalActionSetup;

namespace Game.UIParts.Terminal
{
    public class DoorsOperationItemController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI doorsLocationAtLabelTMP;
        [SerializeField] private LabelText doorsAtLocationAtText;
        [SerializeField] private TextMeshProUGUI doorsLocationTMP;
        [SerializeField] private ButtonController openButton;
        [SerializeField] private ButtonController closeButton;
        [SerializeField] private Camera renderCamera;
        [SerializeField] private RawImage cameraTargetImage;
        [ReadOnly, SerializeField] private Transform cameraHolder;
        [ReadOnly] [SerializeField] private DoorController doorController;
        [ReadOnly, SerializeField] private RenderTexture renderTex;
        private OpenDoorOperationSetting settings;

        public void Set(TerminalActionSetup newSettings)
        {
            if (newSettings.operationType != ETerminalOperationType.OpenDoor) return;

            settings = newSettings.openDoorOperationSetting;
            doorsLocationAtLabelTMP.text = doorsAtLocationAtText.Text;
            doorsLocationTMP.text = settings.location.Text;
            doorController = settings.targetDoor;
            cameraHolder = settings.cameraHolder;
            openButton.OnClickAddListener(OpenAction);
            closeButton.OnClickAddListener(CloseAction);

            var imageTex = cameraTargetImage.texture;
            renderTex = RenderTexture.GetTemporary(imageTex.width, imageTex.height);
            renderTex.depth = 24;

            Transform cameraTransform;
            (cameraTransform = renderCamera.transform).SetParent(cameraHolder);
            // cameraTransform.localPosition = Vector3Extensions.Zero;
            // cameraTransform.localRotation = Quaternion.Euler(Vector3Extensions.Zero);
            cameraTransform.position = cameraHolder.position;
            cameraTransform.rotation = cameraHolder.rotation;
            renderCamera.targetTexture = renderTex;
            cameraTargetImage.texture = renderTex;
            renderCamera.gameObject.SetActive(true);
        }

        private void OpenAction()
        {
            if (settings.unblockUponOpen)
            {
                doorController.SetBlocked(false);
            }
            if (settings.unlockOnOpen)
            {
                doorController.Unlock();
            }
            doorController.Open();
            StartCoroutine(DelayedDoorSetting(false, settings.blockAfterOpen));
        }
        
        private void CloseAction()
        {
            if (settings.unblockUponClose)
            {
                doorController.SetBlocked(false);
            }
            doorController.Close();
            StartCoroutine(DelayedDoorSetting(settings.closeAndLock, settings.blockAfterClose));
        }

        private IEnumerator DelayedDoorSetting(bool locking, bool blocking)
        {
            yield return new WaitForSeconds(1);
            if (locking)
            {
                doorController.Lock();
            }

            if (blocking)
            {
                doorController.SetBlocked(true);
            }
        }

        private void OnDisable()
        {
            openButton.OnClickRemoveListener(OpenAction);
            closeButton.OnClickRemoveListener(CloseAction);
            
            renderCamera.targetTexture = null;
            renderCamera.gameObject.SetActive(false);
            cameraTargetImage.texture = null;
            if (renderTex)
            {
                renderTex.Release();
            }
        }
    }
}
