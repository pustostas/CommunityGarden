import SwiftUI

struct GardensView: View {
    @State private var isSidebarOpen = false
    
    var body: some View {
        NavigationView{
            
        }.toolbar {
            Button("sidebar"){
                isSidebarOpen.toggle()
            }
        }
        .popover(isPresented: $isSidebarOpen,attachmentAnchor: .rect(.bounds),
                 arrowEdge: .top){
            GardenSelectSideBar()
        }
        
    }
}

struct GardensView_Previews: PreviewProvider {
    static var previews: some View {
        GardensView()
    }
}
