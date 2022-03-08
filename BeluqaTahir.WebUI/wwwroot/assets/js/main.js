$(function() {

  var siteSticky = function() {
		$(".js-sticky-header").sticky({topSpacing:0});
	};
	siteSticky();

	var siteMenuClone = function() {

		$('.js-clone-nav').each(function() {
			var $this = $(this);
			$this.clone().attr('class', 'site-nav-wrap').appendTo('.site-mobile-menu-body');
		});


		setTimeout(function() {
			
			var counter = 0;
      $('.site-mobile-menu .has-children').each(function(){
        var $this = $(this);
        
        $this.prepend('<span class="arrow-collapse collapsed">');

        $this.find('.arrow-collapse').attr({
          'data-toggle' : 'collapse',
          'data-target' : '#collapseItem' + counter,
        });

        $this.find('> ul').attr({
          'class' : 'collapse',
          'id' : 'collapseItem' + counter,
        });

        counter++;

      });

    }, 1000);

		$('body').on('click', '.arrow-collapse', function(e) {
      var $this = $(this);
      if ( $this.closest('li').find('.collapse').hasClass('show') ) {
        $this.removeClass('active');
      } else {
        $this.addClass('active');
      }
      e.preventDefault();  
      
    });

		$(window).resize(function() {
			var $this = $(this),
				w = $this.width();

			if ( w > 768 ) {
				if ( $('body').hasClass('offcanvas-menu') ) {
					$('body').removeClass('offcanvas-menu');
				}
			}
		})

		$('body').on('click', '.js-menu-toggle', function(e) {
			var $this = $(this);
			e.preventDefault();

			if ( $('body').hasClass('offcanvas-menu') ) {
				$('body').removeClass('offcanvas-menu');
				$this.removeClass('active');
			} else {
				$('body').addClass('offcanvas-menu');
				$this.addClass('active');
			}
		}) 

		// click outisde offcanvas
		$(document).mouseup(function(e) {
	    var container = $(".site-mobile-menu");
	    if (!container.is(e.target) && container.has(e.target).length === 0) {
	      if ( $('body').hasClass('offcanvas-menu') ) {
					$('body').removeClass('offcanvas-menu');
				}
	    }
		});
	}; 
	siteMenuClone();

});

$(document).ready(function() {

	var counters = $(".count");
	var countersQuantity = counters.length;
	var counter = [];
  
	for (i = 0; i < countersQuantity; i++) {
	  counter[i] = parseInt(counters[i].innerHTML);
	}
  
	var count = function(start, value, id) {
	  var localStart = start;
	  setInterval(function() {
		if (localStart < value) {
		  localStart++;
		  counters[id].innerHTML = localStart;
		}
	  }, 40);
	}
  
	for (j = 0; j < countersQuantity; j++) {
	  count(0, counter[j], j);
	}
  });

  function initEmptySlide() {
	const margin = $(".container")[0].getClientRects()[0].x;
	$(".item1").css("margin-left", Math.floor(margin) - 15);
  }
  
  $(window).resize(function () {
	initEmptySlide();
  });
  
  $(document).on("ready", function () {
	initEmptySlide();
  
	$(".variable").slick({
	  dots: false,
	  focusOnSelect: false,
	  infinite: false,
	  variableWidth: true,
	  slidesToShow: 2,
	  slidesToScroll: 1,
	  prevArrow: $(".prev"),
	  nextArrow: $(".next"),
	  centerPadding: "40px",
	  responsive: [
		{
		  breakpoint: 991,
		  settings: {
			slidesToShow: 2,
			slidesToScroll: 1,
			infinite: true
		  }
		},
		{
		  breakpoint: 600,
		  settings: {
			slidesToShow: 2,
			slidesToScroll: 1,
			dots: false,
			infinite: true
		  }
		}
	  ]
	});
  });

  
  

  
(function ($) {
    "use strict";

    
    /*==================================================================
    [ Validate ]*/
    var input = $('.validate-input .input100');

    $('.validate-form').on('submit',function(){
        var check = true;

        for(var i=0; i<input.length; i++) {
            if(validate(input[i]) == false){
                showValidate(input[i]);
                check=false;
            }
        }

        return check;
    });


    $('.validate-form .input100').each(function(){
        $(this).focus(function(){
           hideValidate(this);
        });
    });

    function validate (input) {
        if($(input).attr('type') == 'email' || $(input).attr('name') == 'email') {
            if($(input).val().trim().match(/^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{1,5}|[0-9]{1,3})(\]?)$/) == null) {
                return false;
            }
        }
        else {
            if($(input).val().trim() == ''){
                return false;
            }
        }
    }

    function showValidate(input) {
        var thisAlert = $(input).parent();

        $(thisAlert).addClass('alert-validate');
    }

    function hideValidate(input) {
        var thisAlert = $(input).parent();

        $(thisAlert).removeClass('alert-validate');
    }
    
    

})(jQuery);


(function() {
		
	let field = document.querySelector('.itemsss');
	let li = Array.from(field.children);

	function FilterProduct() {
		for(let i of li){
			const name = i.querySelector('strong');
			const x = name.textContent;
			i.setAttribute("data-category", x);
		}

		let indicator = document.querySelector('.indicator').children;

		this.run = function() {
			for(let i=0; i<indicator.length; i++)
			{
				indicator[i].onclick = function () {
					for(let x=0; x<indicator.length; x++)
					{
						indicator[x].classList.remove('active');
					}
					this.classList.add('active');
					const displayItems = this.getAttribute('data-filter');

					for(let z=0; z<li.length; z++)
					{
						li[z].style.transform = "scale(0)";
						setTimeout(()=>{
							li[z].style.display = "none";
						}, 500);

						if ((li[z].getAttribute('data-category') == displayItems) || displayItems == "all")
						 {
							 li[z].style.transform = "scale(1)";
							 setTimeout(()=>{
								li[z].style.display = "block";
							}, 500);
						 }
					}
				};
			}
		}
	}

	function SortProduct() {
		let select = document.getElementById('select');
		let ar = [];
		for(let i of li){
			const last = i.lastElementChild;
			const x = last.textContent.trim();
			const y = Number(x.substring(1));
			i.setAttribute("data-price", y);
			ar.push(i);
		}
		this.run = ()=>{
			addevent();
		}
		function addevent(){
			select.onchange = sortingValue;
		}
		function sortingValue(){
		
			if (this.value === 'Default') {
				while (field.firstChild) {field.removeChild(field.firstChild);}
				field.append(...ar);	
			}
			if (this.value === 'LowToHigh') {
				SortElem(field, li, true)
			}
			if (this.value === 'HighToLow') {
				SortElem(field, li, false)
			}
		}
		function SortElem(field,li, asc){
			let  dm, sortli;
			dm = asc ? 1 : -1;
			sortli = li.sort((a, b)=>{
				const ax = a.getAttribute('data-price');
				const bx = b.getAttribute('data-price');
				return ax > bx ? (1*dm) : (-1*dm);
			});
			 while (field.firstChild) {field.removeChild(field.firstChild);}
			 field.append(...sortli);	
		}
	}

	new FilterProduct().run();
	new SortProduct().run();
})();