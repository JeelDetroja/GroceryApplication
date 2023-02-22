const $form = $('.card__form');

$form.submit(event => {
    event.preventDefault();

    $form.addClass('form-submitted');

    setTimeout(() => {
        $form.addClass('form-done');

        setTimeout(() => {
            $form.
                removeClass('form-submitted').
                removeClass('form-done');
        }, 250);
    }, 2650);
});