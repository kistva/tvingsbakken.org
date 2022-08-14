function Pagination() {
    
    let objJson = {};
    const monthNames = ["Jan", "Feb", "Mar", "Apr", "Maj", "Jun","Jul", "Aug", "Sep", "Okt", "Nov", "Dec"];
    const prevButton = document.getElementById('button-prev');
    const nextButton = document.getElementById('button-next');
    
    let current_page = 1;
    let records_per_page = 3;
    let number_of_pages = 0;
    
    this.init = function() {
      RenderBlogs();
      //changePage(1);
      
      clickPage();
      addEventListeners();
    }

    const GetBlogs = async (pageNumber) => {
      try {
        let url = "/api/blogs/";
        url = pageNumber != null ? url + pageNumber : url;
        const res = await fetch(url);
        const data = await res.json();
        objJson = data;
        return data
      } catch (err) {
          console.error(err);
      }
  }



    function RenderBlogs() {
      GetBlogs(current_page).then(data => {
        pageNumbers();
        selectedPage();
      });
    }

    let addEventListeners = function() {
        prevButton.addEventListener('click', prevPage);
        nextButton.addEventListener('click', nextPage);   
    }
    let selectedPage = function() {
        let page_number = document.getElementById('page_number').getElementsByClassName('clickPageNumber'); 
        for (let i = 0; i < page_number.length; i++) {
            if (i == current_page - 1) {
                page_number[i].classList.add('active');
            } 
            else {
                page_number[i].classList.remove('active');
            }
        }
    }  
    
    let checkButtonOpacity = function() {
      current_page == 1 ? prevButton.classList.add('opacity') : prevButton.classList.remove('opacity');
      current_page == numPages() ? nextButton.classList.add('opacity') : nextButton.classList.remove('opacity');
    }

    let changePage = function(page) {
      GetBlogs(page).then(data => { 
        objJson = data;
        const blogList = document.getElementById('blog-row');
        if (page < 1) {
            page = 1;
        } 
        if (page > (numPages() -1)) {
            page = numPages();
        }
        blogList.classList.add('blog-hide');
        blogList.classList.remove('blog-down');
        blogList.innerHTML = "";
        let html = "";
        for(var i = 0; (i < records_per_page && objJson.total > (i + records_per_page * (page-1)) ); i++) {
          var dateObj = objJson.result[i].publishDate;
          var dateStr = Date.parse(dateObj);  
          var date = new Date(dateStr);
          let htmlSegment = `<a href="${objJson.result[i].url}" alt="${objJson.result[i].altTitle}">
            <div class="cols-3">
              <div class="blog-col">
                  <div class="blog-date">
                      <div class="blog-date-day">${date.getDate()}</div>
                      <div class="blog-date-month">${monthNames[date.getMonth()]}.</div>
                      <div class="blog-date-year">${date.getFullYear()}</div>
                  </div>
                  <div class="blog-content">
                      <h2>${objJson.result[i].title}</h2>
                      <p>${objJson.result[i].text}</p>
                  </div>
              </div>
            </div>
          </a>`;
          html += htmlSegment;
          var myVar = setTimeout(slideIn, 500)
        }
        
        blogList.innerHTML = html;  
        checkButtonOpacity();
        selectedPage();
      });
    }

    

    let slideIn = function() {
      console.log("slideIn")
      const blogList = document.getElementById('blog-row');
      blogList.classList.remove('blog-hide');
      blogList.classList.add('blog-down');
    }

    let prevPage = function() {

        if(current_page > 1) {
            current_page--;
            changePage(current_page);
        }
    }

    let nextPage = function() {
        if(current_page < numPages()) {
            current_page++;
            changePage(current_page);
        } 
    }

    let clickPage = function() {
        document.addEventListener('click', function(e) {
            if(e.target.nodeName == "SPAN" && e.target.classList.contains("clickPageNumber")) {
                current_page = e.target.textContent;
                changePage(current_page);
            }
        });
    }

    let pageNumbers = function() {

        let pageNumber = document.getElementById('page_number');
        pageNumber.innerHTML = "";
        for(let i = 1; i < numPages() + 1; i++) {
            pageNumber.innerHTML += "<span class='clickPageNumber'>" + i + "</span>";
        }
    }

    let numPages = function() {
        return objJson.numberOfPages;  
    }
 }


document.addEventListener("DOMContentLoaded", function() {

  var scrollUp = document.querySelector('.scrollup');
  window.onscroll = function() {
    if (document.body.scrollTop() > 100) {
      scrollUp.classList.remove('fadeout');
      scrollUp.classList.add('fadein');
    } else {
      scrollUp.classList.remove('fadein');
      scrollUp.classList.add('fadeout');
    }
  };

  scrollUp.addEventListener("click", function() {
    window.scrollTo({ top: 0, left: 0, behavior: 'smooth' });
  });


  function scrollFunction() {
    if (document.body.scrollTop > 100 || document.documentElement.scrollTop > 100) {
      document.getElementById("Header").classList.remove("maximized");
      document.getElementById("Header").classList.add("minimized");
    } else {
      document.getElementById("Header").classList.remove("minimized");
      document.getElementById("Header").classList.add("maximized");
    }
  }  

  window.onscroll = function() {scrollFunction()};


  var burger = document.querySelector(".burger");
  burger.addEventListener("click", function() {
    burger.classList.toggle('active');
    document.getElementById("Menu").classList.toggle("showMenu");
  });




  var filters = document.querySelectorAll('.filter');
  filters.forEach(filter => { 
    filter.addEventListener('click', function() {

      let selectedFilter = filter.getAttribute('data-filter');
      let itemsToHide = document.querySelectorAll(`.gallery-images .gallery-image:not([data-filter='${selectedFilter}'])`);
      let itemsToShow = document.querySelectorAll(`.gallery-images [data-filter='${selectedFilter}']`);

      filters.forEach(f => {
        f.classList.remove('current');
      });
      filter.classList.add('current');

      if (selectedFilter == 'all') {
        itemsToHide = [];
        itemsToShow = document.querySelectorAll('.gallery-images [data-filter]');
      }

      itemsToHide.forEach(el => {
        el.classList.add('hide-gallery-image');
        el.classList.remove('show-gallery-image');
      });

      itemsToShow.forEach(el => {
        el.classList.remove('hide-gallery-image');
        el.classList.add('show-gallery-image'); 
      });

    });
  
  
  });  

  var modal = document.getElementById("myModal");
  var modalImg = document.getElementById("modalImg");
  var captionText = document.getElementById("caption");
  
  document.querySelectorAll('.Image').forEach(item => {
    item.addEventListener('click', event => {
      modal.style.display = "block";
      modalImg.src = item.getAttribute('data');
      captionText.innerHTML = item.alt;
    })
  })


  document.querySelectorAll('.close').forEach(item => {
    item.addEventListener('click', event => {
      modal.style.display = "none";
    });
  });

  document.querySelectorAll('.modal-content').forEach(item => {
    item.addEventListener('click', event => {
      modal.style.display = "none";
    });
  });

  document.querySelectorAll('.blog-row').forEach(item => {
    let pagination = new Pagination();
    pagination.init();
  });


});

