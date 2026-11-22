/* Mailora ortak form yardımcıları. Bu dosyayı login.js ve register.js'den önce yükleyin. */
window.MailoraCommon = (() => {
    const $ = (selector, root = document) => root.querySelector(selector);
    const $$ = (selector, root = document) => [...root.querySelectorAll(selector)];

    function toast(title, text = '', type = 'info', icon = 'bi-info-circle') {
        const el = document.createElement('div');
        el.className = `m-toast ${type}`;
        el.innerHTML = `<span class="ti"><i class="bi ${icon}"></i></span><span><b>${title}</b>${text}</span>`;
        $('#toastStack').appendChild(el);
        setTimeout(() => { el.classList.add('out'); setTimeout(() => el.remove(), 250); }, 3600);
    }

    function bindCapsLock(input) {
        const caps = $('.caps', input.closest('.field'));
        input.addEventListener('keyup', e => caps.classList.toggle('show', !!(e.getModifierState && e.getModifierState('CapsLock'))));
        input.addEventListener('blur', () => caps.classList.remove('show'));
    }

    function bindPasswordEyes() {
        $$('[data-eye]').forEach(btn => btn.addEventListener('click', () => {
            const input = $('#' + btn.dataset.eye), show = input.type === 'password';
            input.type = show ? 'text' : 'password';
            $('i', btn).className = show ? 'bi bi-eye-slash' : 'bi bi-eye';
            btn.title = show ? 'Şifreyi gizle' : 'Şifreyi göster';
            btn.setAttribute('aria-label', btn.title);
            input.focus({ preventScroll: true });
            const len = input.value.length;
            try { input.setSelectionRange(len, len); } catch { /* Şifre alanı değilse seçim yapılamaz. */ }
        }));
    }

    return { $, $$, toast, bindCapsLock, bindPasswordEyes };
})();
