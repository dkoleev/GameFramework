using TMPro;
using UnityEditor;
using UnityEngine;

namespace Avocado.Toolbox.Text {
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class TMPBitmapOutline : MonoBehaviour {
       [Header("Outline Settings")]
        public Color outlineColor = new(0.24f, 0.12f, 0f);
        [Range(0f, 10f)] public float thickness = 1f;

        private TextMeshProUGUI _mainText;
        private readonly TextMeshProUGUI[] _outlines = new TextMeshProUGUI[8];
        private static readonly Vector2[] Offsets = {
            new(-1, 0), new(1, 0), new(0, -1), new(0, 1),
            new(-1, -1), new(1, 1), new(-1, 1), new(1, -1)
        };

        private string _lastText;
        private float _lastFontSize;
        private Color _lastOutlineColor;
        private float _lastThickness;

        private void Awake() {
            Initialize();
            UpdateOutlines(true);
        }

        private void OnEnable() {
            Initialize();
            UpdateOutlines(true);
        }

#if UNITY_EDITOR
        private void OnValidate() {
            if (!Application.isPlaying)
                EditorApplication.delayCall += () => {
                    if (this != null)
                        UpdateOutlines(true);
                };
        }
#endif

        private void LateUpdate() {
            if (_mainText.text != _lastText ||
                Mathf.Abs(_mainText.fontSize - _lastFontSize) > 0.01f ||
                outlineColor != _lastOutlineColor ||
                Mathf.Abs(thickness - _lastThickness) > 0.01f) {
                UpdateOutlines();
            }
        }

        private void Initialize() {
            if (_mainText == null)
                _mainText = GetComponent<TextMeshProUGUI>();

            var parent = transform.parent;

            for (int i = 0; i < _outlines.Length; i++) {
                if (_outlines[i] == null) {
                    var name = $"Outline_{i}";
                    var existing = parent.Find(name);
                    TextMeshProUGUI tmp;

                    if (existing != null)
                        tmp = existing.GetComponent<TextMeshProUGUI>();
                    else {
                        var go = new GameObject(name);
                        go.transform.SetParent(parent, false);
                        tmp = go.AddComponent<TextMeshProUGUI>();
                    }

                    _outlines[i] = tmp;
                }
            }
            
            transform.SetAsLastSibling();
        }

        private void UpdateOutlines(bool force = false) {
            if (_mainText == null) return;

            for (int i = 0; i < _outlines.Length; i++) {
                var outline = _outlines[i];
                if (outline == null) continue;

                var rt = outline.rectTransform;
                var mainRT = _mainText.rectTransform;

                // Копируем RectTransform
                rt.anchorMin = mainRT.anchorMin;
                rt.anchorMax = mainRT.anchorMax;
                rt.pivot = mainRT.pivot;
                rt.sizeDelta = mainRT.sizeDelta;
                rt.localRotation = mainRT.localRotation;
                rt.localScale = mainRT.localScale;
                rt.position = mainRT.position; // важно: используем world position

                outline.text = _mainText.text;
                outline.font = _mainText.font;
                outline.fontSize = _mainText.fontSize;
                outline.alignment = _mainText.alignment;
                outline.characterSpacing = _mainText.characterSpacing;
                outline.fontStyle = _mainText.fontStyle;
                outline.color = outlineColor;

                outline.rectTransform.anchoredPosition = Offsets[i] * thickness;
            }
            
            transform.SetAsLastSibling();

            _lastText = _mainText.text;
            _lastFontSize = _mainText.fontSize;
            _lastOutlineColor = outlineColor;
            _lastThickness = thickness;
        }

#if UNITY_EDITOR
        private void OnDestroy() {
            if (!Application.isPlaying) {
                foreach (var o in _outlines)
                    if (o != null)
                        DestroyImmediate(o.gameObject);
            }
        }
#endif
    }
}
