const { $, $$, toast, bindCapsLock, bindPasswordEyes } = window.MailoraCommon;
const form = $('#loginForm');
const KEYS = ['userName', 'password'];
const touched = new Set();

function validate(key) {
    const value = $('#' + key).value;
    if (key === 'userName' && !value.trim()) return 'Kullanıcı adınızı girin.';
    if (key === 'password' && !value) return 'Şifrenizi girin.';
    return '';
}

function paint(key, { shake = false } = {}) {
    const field = $(`[data-field="${key}"]`), msg = $('.msg', field);
    const error = validate(key);
    field.classList.toggle('is-invalid', !!error);
    msg.textContent = error;
    $('#' + key).setAttribute('aria-invalid', error ? 'true' : 'false');
    if (error && shake) {
        field.classList.remove('shake');
        void field.offsetWidth;
        field.classList.add('shake');
    }
    return !error;
}

KEYS.forEach(key => {
    const input = $('#' + key);
    input.addEventListener('input', () => { if (touched.has(key)) paint(key); });
    input.addEventListener('blur', () => {
        if (!input.value && !touched.has(key)) return;
        touched.add(key);
        paint(key);
    });
});

const password = $('#password');
bindCapsLock(password);
bindPasswordEyes();

$('#forgotLink').addEventListener('click', event => {
    event.preventDefault();
    toast('Şifremi unuttum', 'Şifre sıfırlama sayfası sonraki adımda eklenecek.', 'info', 'bi-key');
});

form.addEventListener('submit', event => {
    KEYS.forEach(key => touched.add(key));
    const results = KEYS.map(key => paint(key, { shake: true }));
    const firstInvalid = KEYS.find((key, index) => !results[index]);

    if (firstInvalid) {
        event.preventDefault();
        $('#' + firstInvalid).focus();
        toast('Formu kontrol edin', 'Kullanıcı adı ve şifre zorunludur.', 'error', 'bi-exclamation-circle');
        return;
    }

    const button = $('#submitBtn');
    button.disabled = true;
    button.innerHTML = '<span class="spinner-sm"></span><span class="lbl">Giriş yapılıyor…</span>';
    // preventDefault çağrılmadığı için form normal şekilde POST edilir.
});
