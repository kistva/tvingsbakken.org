function Pagination() {
    
    let objJson = {};
    const monthNames = ["Jan", "Feb", "Mar", "Apr", "Maj", "Jun","Jul", "Aug", "Sep", "Okt", "Nov", "Dec"];
    
    let current_page = 1;
    let records_per_page = 3;
    let total = 0;
    
    this.init = function() {
      RenderBlogs();
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
      });
    } 
    
    let checkButtonOpacity = function() {
      let prevButton = document.getElementById('button-prev');
      current_page == 1 ? prevButton.classList.add('opacity') : prevButton.classList.remove('opacity');
      let nextButton = document.getElementById('button-next');
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
        pageNumbers();
      });
    }

    

    let slideIn = function() {
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

    let setPagination = function() {
      if (total <= 7) {
        let arr = [];
        for (let i = 1; i <= total; i++) {
          arr.push(i);
        }
        return arr;
      }
      if (current_page <= 4) {
        return [1, 2, 3, 4, 5, "...", total];
      }
      if (current_page > 4 && current_page < total - 3) {
        return [1, "...", current_page - 1, current_page, current_page + 1, "...", total];
      }
      if (current_page > total - 4) {
        return [1, "...", total - 4, total - 3, total - 2, total - 1, total];
      }
    }

    let pageNumbers = function() {

        total = numPages();
        let pageNumber = document.getElementById('page_number');

        while (pageNumber.hasChildNodes()) {
          pageNumber.removeChild(pageNumber.firstChild);
        }

        let buttonPrev = document.createElement('li');
        buttonPrev.textContent = "<";
        buttonPrev.id = "button-prev";
        buttonPrev.addEventListener("click", function() {
          console.log("click pre")
          prevPage();
        });
        if(current_page == 1)
          buttonPrev.classList.add('inactive');

        pageNumber.appendChild(buttonPrev)

        let paginationArray = setPagination();

        paginationArray.forEach((i) => {
          let pageNumberBtn = document.createElement('li');
          pageNumberBtn.textContent = i;

          if(i !== "...")
          {
            pageNumberBtn.classList.add("clickPageNumber");
            pageNumberBtn.addEventListener("click", function(e) {
              current_page = Number(e.target.textContent);
              changePage(current_page);
            });
          }
          else
          {
            pageNumberBtn.classList.add("noborder");
          }

          if (i == current_page) {
            pageNumberBtn.classList.add('active');
          }
          pageNumber.appendChild(pageNumberBtn)

        })

        let buttonNext = document.createElement('li');
        buttonNext.textContent = ">";
        buttonNext.id = "button-next";
        buttonNext.addEventListener("click", function() {
          nextPage();
        });
        if(current_page == numPages())
          buttonNext.classList.add('inactive');
        pageNumber.appendChild(buttonNext)

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

