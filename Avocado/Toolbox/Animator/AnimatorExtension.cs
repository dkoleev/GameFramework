namespace Avocado.Toolbox.Animator
{
    public static class AnimatorExtension
    {
        public static void PlayState(this UnityEngine.Animator animator, string stateName, int layer = 0)
        {
            // Проверяем, чтобы animator был активен
            if (animator == null || !animator.isActiveAndEnabled)
            {
                return;
            }

            // Переводим Animator в "пустое" состояние, чтобы сбросить текущее
            animator.Play("Idle", layer, 0f);
            animator.Update(0f);

            // Запускаем нужную анимацию с начала
            animator.Play(stateName, layer, 0f);
        }
    }
}
