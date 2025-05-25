using System;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace ZENGAME
{
    public class AttentionPointController : ITickable
    {
        public Action OnFinished;
        
        private readonly AttentionPointView _attentionPointView;
        private readonly Settings _settings;
        
        private float _timer = 0;
        private float _currentTime = 0;

        private bool _isEnabled;
        private bool _isBlinked;
    
        public AttentionPointController(AttentionPointView attentionPointView, Settings settings)
        {
            _attentionPointView = attentionPointView;
            _settings = settings;
        }

        public void Start()
        {
            _isEnabled = true;
            ResetTimer();
        }

        public void Dispose()
        {
            _isEnabled = false;
        }
        
        public void Tick()
        {
            if (!_isEnabled) return;
                
            HandleTimer();
        }

        private void HandleTimer()
        {
            _currentTime += Time.deltaTime;

            if (!_isBlinked && _currentTime > _timer)
            {
                _attentionPointView.Blink();
                _isBlinked = true;
            }
                
            if (Input.GetMouseButtonDown(1))
            {
                if (_currentTime > _timer && _currentTime <= _timer + _settings.reactionTime)
                {
                    ResetTimer();
                    return;
                }
                else
                {
                    OnFinished?.Invoke();
                }
            }

            if (_currentTime > _timer + _settings.reactionTime) OnFinished?.Invoke();
        }

        private void ResetTimer()
        {
            _currentTime = 0;
            _timer = Random.Range(_settings.minTimer, _settings.maxTimer);
            _isBlinked = false;
        }

        [Serializable]
        public class Settings
        {
            public float minTimer = 2f;
            public float maxTimer = 30f;
            
            public float reactionTime = 0.2f;
        }
    }
}