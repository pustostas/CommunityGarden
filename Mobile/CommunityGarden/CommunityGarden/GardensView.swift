import SwiftUI

struct GardensView: View {
    @State private var isSidebarOpened = false
    private var gardenNames = ["Garden 1", "Garden 2"]
    var body: some View {
        ZStack {
            NavigationView {
                List {
                    ForEach(gardenNames, id: \.self) { gardenName in
                        NavigationLink(destination: PlantsView()){
                        Text(gardenName)
                        }
                    }
                    }
                    .toolbar {
                        Button {
                            isSidebarOpened.toggle()
                        } label: {
                            Label("Toggle SideBar",
                          systemImage: "line.3.horizontal.circle.fill")
                                .font(.title)
                        }
                    }
                    .listStyle(.inset)
                    .navigationTitle("Gardens")
                    .navigationBarTitleDisplayMode(.inline)
         
            }
            SideBar(isSidebarVisible: $isSidebarOpened,isGardenView: true)
        }
    }
}


struct GardensView_Previews: PreviewProvider {
    static var previews: some View {
        GardensView()
    }
}
